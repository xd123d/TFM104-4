using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TFM104MVC.Dtos;
using TFM104MVC.Models;
using TFM104MVC.Services;

namespace TFM104MVC.Controllers
{

    [ApiController]
    [Route("{auth}")]
    public class AuthenticateController:ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IAuthenticateRepository _authenticateRepository;
        private readonly IMapper _mapper;
        private readonly ISender _sender;
        private readonly IProductRepository _productRepository;
        public AuthenticateController(IConfiguration configuration,IAuthenticateRepository authenticateRepository,IMapper mapper,ISender sender,IProductRepository productRepository)

        {
            _configuration = configuration;
            _authenticateRepository = authenticateRepository;
            _mapper = mapper;
            _sender = sender;
            _productRepository = productRepository;

        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody]LoginDto loginDto)
        {
            // 1.驗證帳號與密碼正確與否
            //先驗證帳號 看有沒有此帳號存在 如果沒有 返回帳號密碼錯誤
            //若成功 則得到資料庫裡面這位User的資料 就可以把他的密碼和鹽拿出來做處理
            var loginUser = _authenticateRepository.AccountCheck(loginDto.Account);

            //var loginUser = _authenticateRepository.CheckUser(loginDto.Account, loginDto.Password);
            if(loginUser == null)
            {
                return NotFound("帳號或密碼錯誤");
            }
            string salt = loginUser.Salt;
            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(loginDto.Password + salt);
            byte[] hashBytes = new SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashStr = Convert.ToBase64String(hashBytes);
            //驗證密碼
            var loginPasswordCheck = _authenticateRepository.CheckUser(loginDto.Account,hashStr);
            if(loginPasswordCheck == null)
            {
                return NotFound("帳號密碼錯誤");
            }

            // 2.若正確 則創建JWT Token
            // header (SHA256加密Header)
            var signinAlgorithm = SecurityAlgorithms.HmacSha256;
            // payload
            var claims = new[]
            {
                // sub
                new Claim(JwtRegisteredClaimNames.Sub,loginUser.Id.ToString()),
                new Claim(ClaimTypes.Role,loginUser.RoleName),
                new Claim("userId",loginUser.Id.ToString())
            };
            // signiture
            var secretByte = Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]);
            var signinKey = new SymmetricSecurityKey(secretByte);
            var signinCredentials = new SigningCredentials(signinKey, signinAlgorithm);

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"] ,
                audience: _configuration["Authentication:Audience"],
                claims,
                notBefore:DateTime.UtcNow,
                expires:DateTime.UtcNow.AddDays(1),
                signinCredentials
                );
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);
            // 3.return 200 ok + jwt
            return Ok(tokenStr);
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> register([FromBody] UserForCreationDto userForCreationDto)
        {
            var userModel = _mapper.Map<User>(userForCreationDto);

            string salt = Guid.NewGuid().ToString();
            string password = userForCreationDto.Password;
            byte[] passwordWithSaltBytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hashByte = new SHA256Managed().ComputeHash(passwordWithSaltBytes);
            string hashStr = Convert.ToBase64String(hashByte);

            userModel.Password = hashStr;
            userModel.Salt = salt;


            var accountCheck = _authenticateRepository.AccountCheck(userForCreationDto.Account);
            if(accountCheck != null)
            {
                return NotFound("帳號重複 請更換帳號名稱");
            }
            _authenticateRepository.AddUser(userModel);
            _authenticateRepository.Save();

            string Url = "https://localhost:5001/auth/open?account=" + userForCreationDto.Account; //之後改成發布後的網址
            string messageUrl = $"<a href='{Url}'>我是開通帳號小精靈~~</a>";
            string subject = "註冊驗證信";
            string message = "恭喜註冊成功，請點擊以下文字開通您的帳號" +"<br>" + messageUrl;
            _sender.Sender(userModel.Account, subject, message);

            //給新用戶在註冊時就初始化購物車
            var shoppingCart = new ShoppingCart()
            {
                UserId = userModel.Id
            };
            await _productRepository.CreateShoppingCart(shoppingCart);
            await _productRepository.SaveAsync();

            return Ok("註冊成功");
        }

        [AllowAnonymous]
        [HttpPost("open")]
        public IActionResult OpenAccount([FromQuery] string account)
        {
            var userFromRepo = _authenticateRepository.AccountCheck(account);

            if(userFromRepo == null)
            {
                throw new ArgumentNullException();
            }

            userFromRepo.Verification = true;
            _authenticateRepository.Save();

            return NoContent();
        }

        [AllowAnonymous]
        [HttpPut("update")]
        public IActionResult UpdatePassword([FromBody] LoginDto updatePasswordDto)
        {
            var userExist = _authenticateRepository.AccountCheck(updatePasswordDto.Account);
            if(userExist == null)
            {
                return NotFound("無此使用者帳號");
            }
            string oldSalt = userExist.Salt;

            string newPassword = updatePasswordDto.Password;
            byte[] newPasswordWithOldSalt = Encoding.UTF8.GetBytes(newPassword + oldSalt);
            byte[] hashByte = new SHA256Managed().ComputeHash(newPasswordWithOldSalt);
            string hashStr = Convert.ToBase64String(hashByte);
            userExist.Password = hashStr;

            _authenticateRepository.Save();

            return Ok("更新密碼完成，請妥善保管您的密碼");

        }
        //    _authenticateRepository.AddUser(userModel);
        //    _authenticateRepository.Save();
        //    return Ok("註冊成功");
        //}
    }
}
