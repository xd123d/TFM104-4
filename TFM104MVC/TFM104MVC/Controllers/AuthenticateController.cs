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
        public AuthenticateController(IConfiguration configuration,IAuthenticateRepository authenticateRepository,IMapper mapper)
        {
            _configuration = configuration;
            _authenticateRepository = authenticateRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult login([FromBody]LoginDto loginDto)
        {
            // 1. 驗證帳號與密碼正確與否 //TODO
            var loginUser = _authenticateRepository.CheckUser(loginDto.Account, loginDto.Password);
            if(loginUser == null)
            {
                return NotFound("帳號或密碼錯誤");
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
        public IActionResult register([FromBody] UserForCreationDto userForCreationDto)
        {
            var userModel = _mapper.Map<User>(userForCreationDto);
            var accountCheck = _authenticateRepository.AccountCheck(userForCreationDto.Account);
            if(accountCheck != null)
            {
                return NotFound("帳號重複 請更換帳號名稱");
            }
            _authenticateRepository.AddUser(userModel);
            _authenticateRepository.Save();
            return Ok("註冊成功");
        }

    }
}
