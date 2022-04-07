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
            var productsFromRepo = await _productRepository.GetProductsAsync(parameters.Keyword, operatorType, ratingValue, parameters.Region, parameters.Traveldays, parameters.Triptype);

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
        [Authorize(Roles ="Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")]
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
