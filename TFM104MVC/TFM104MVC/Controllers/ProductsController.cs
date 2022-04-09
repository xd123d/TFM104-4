 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFM104MVC.Dtos;
using TFM104MVC.Services;
using AutoMapper;
using System.Text.RegularExpressions;
using TFM104MVC.ResouceParameters;
using TFM104MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace TFM104MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        public ProductsController(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _environment = webHostEnvironment;
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetProducts(
            [FromQuery] ProductResourceParameters parameters
            //[FromQuery] string keyword,
            //string rating
            )
        {
            Regex regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
            string operatorType = "";
            int ratingValue = -1;
            if (!string.IsNullOrWhiteSpace(parameters.Rating))
            {
                Match match = regex.Match(parameters.Rating);

                if (match.Success)
                {
                    operatorType = match.Groups[1].Value;
                    ratingValue = int.Parse(match.Groups[2].Value);
                }
            }
            var productsFromRepo = await _productRepository.GetProductsAsync(parameters.Keyword, operatorType, ratingValue, parameters.Region, parameters.Traveldays, parameters.Triptype,parameters.PageSize,parameters.PageNumber);

            if (productsFromRepo == null || productsFromRepo.Count() <= 0)
            {
                return NotFound("目前沒有商品資料");
            }
            //return Ok(productsFromRepo);
            var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);
            return Ok(productsDto);
        }

        // api/products/{productId}
        [HttpGet("{productId}", Name = "GetProductById")] //使用動態路由格式{} 代表路由的最後一格 {productId} 會對應到參數傳進來
        [HttpHead]
        public async Task<IActionResult> GetProductById(Guid productId)
        {
            var productFromRepo = await _productRepository.GetProductAsync(productId);
            if (productFromRepo == null)
            {
                return NotFound($"找不到編號為{productId}的商品");
            }
            //var productDto = new ProductDto()
            //{
            //    Id = productFromRepo.Id,
            //    Title = productFromRepo.Title,
            //    Description = productFromRepo.Description,
            //    Price = productFromRepo.OriginalPrice * (decimal)(productFromRepo.DiscountPersent),
            //    CreateDate = productFromRepo.CreateDate,
            //    UpdateTime = productFromRepo.UpdateTime,
            //    GoTouristTime = productFromRepo.GoTouristTime,
            //    Notes = productFromRepo.Notes,
            //    CustomerRating = productFromRepo.CustomerRating,
            //    TravelDays = productFromRepo.TravelDays.ToString(),
            //    TripType = productFromRepo.TripType.ToString(),
            //    Region = productFromRepo.Region.ToString()
            //};
            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            return Ok(productDto);
        }

        [HttpPost] // api/products
        [Authorize(Roles ="Admin,Firm")]
        [Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreationDto productCreationDto)
        {
            string rootRoot = _environment.ContentRootPath + @"\wwwroot\ProductPictures\";
            var productModel = _mapper.Map<Product>(productCreationDto);// 此時Id已被profile檔案投影出一個新的Guid Id
            var files = productCreationDto.Pic;
            foreach(var file in files)
            {
                ProductPicture productPicture = new ProductPicture();
                if (file.Length > 0)
                {
                    var stream = System.IO.File.Create(rootRoot + DateTime.Now.Ticks.ToString()+file.FileName);
                    file.CopyTo(stream);
                    productPicture.Url = rootRoot + DateTime.Now.Ticks.ToString() + file.FileName;
                }
                productModel.ProductPictures.Add(productPicture);
            }
            _productRepository.AddProduct(productModel); //這時候只是被寫入數據上下文當中 還沒真正與資料庫互動
            await _productRepository.SaveAsync();
            var productToReturn = _mapper.Map<ProductDto>(productModel);
            return CreatedAtRoute("GetProductById", new { productId = productToReturn.Id },productToReturn);
        }

        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin,Firm")]
        public async Task<IActionResult> UpdateProduct(
            [FromRoute]Guid productId,
            [FromBody]ProductUpdateDto productUpdateDto
            )
        {
            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound("沒有此商品");
            }
            var productFromRepo = await _productRepository.GetProductAsync(productId);
            // 1.把從倉庫提取出來的數據映射為Dto
            // 2.更新這個Dto數據
            // 3.更新完後再映射回原本的Repo
            _mapper.Map(productUpdateDto, productFromRepo);

            await _productRepository.SaveAsync();

            return NoContent();
        }

        [HttpPatch("{productId}")]
        public async Task<IActionResult> PartiallyUpdateProfuct(
            [FromRoute]Guid productId,
            [FromBody] JsonPatchDocument<ProductUpdateDto> patchDocument)
        {

            if (!(await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound("此商品不存在");
            }

            //要更新數據 首先要得到此在資料庫裡的數據
            var productFromRepo = await _productRepository.GetProductAsync(productId);
            //得到後 打上補丁
            //JsonPatch一定要對應到參數的類型 所以使用automapper 把原始productFromRepo倒給傳遞進來的ProductUpdateDto類型
            //先去profile文件新增映射關係
            var productToPatch = _mapper.Map<ProductUpdateDto>(productFromRepo);
            //參數對應成功後 把數據打上補丁 使用JsonPatchDocument內建method 代表這個補丁成功打給了productToPatch
            patchDocument.ApplyTo(productToPatch,ModelState);
            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }
            //最後再把productToPatch倒給product型態的productFromRepo 存入資料庫中
            _mapper.Map(productToPatch, productFromRepo); // .Map(輸入的數據,輸出的數據) 為什麼不是.Map<>() 因為這個是既有的資料更新 不是新增
            await _productRepository.SaveAsync();

            return NoContent();
        }
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin,Firm")]
        public async Task<IActionResult> DeleteProduct([FromRoute]Guid productId)
        {
            if (!( await _productRepository.ProductExistAsync(productId)))
            {
                return NotFound("沒有此商品");
            }
            var result = await _productRepository.GetProductAsync(productId);
            _productRepository.DeleteProduct(result);
            await _productRepository.SaveAsync();

            return NoContent();
        }
    }
}
