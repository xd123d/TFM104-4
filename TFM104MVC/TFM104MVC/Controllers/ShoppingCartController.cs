using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TFM104MVC.Dtos;
using TFM104MVC.Models;
using TFM104MVC.Services;

namespace TFM104MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor; //此建構子代表可叫用method取得http數據上下文當中的資訊
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ShoppingCartController(IHttpContextAccessor httpContextAccessor,IProductRepository productRepository,IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> GetShoppingCart()
        {
            //1.獲得當前用戶
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("userId");

            //2.使用userId獲得購物車
            var shoppingCart = await _productRepository.GetShoppingCartByUserId(userId);

            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));

        }
        [HttpPost("items")] // api/shoppingcart/items
        [Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> AddShoppingCartItem([FromBody] AddShoppingCartItemDto addShoppingCartItemDto)
        {
            //1.獲得當前用戶
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("userId");

            //2.使用userId獲得購物車
            var shoppingCart = await _productRepository.GetShoppingCartByUserId(userId);

            //3.使用[Frombody]參數來創建LineItem
            //3.1 取得特定商品資料
            var productFromRepo = await _productRepository.GetProductAsync(addShoppingCartItemDto.ProductId);
            if(productFromRepo == null)
            {
                return NotFound("此商品不存在");
            }

            var lineItem = new LineItem()
            {
                // LineItem Id為自動遞增 所以不用處理它
                ProductId = addShoppingCartItemDto.ProductId,
                ShoppingCartId = shoppingCart.Id,
                OriginalPrice = productFromRepo.OriginalPrice,
                DiscountPersent = productFromRepo.DiscountPersent
            };

            //添加進LineItem資料庫
            await _productRepository.AddShoppingCartItem(lineItem);
            await _productRepository.SaveAsync();

            return Ok(_mapper.Map<ShoppingCartDto>(shoppingCart));
        }

        [HttpDelete("items/{itemId}")]
        [Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> DeleteShoppingCartItem([FromRoute] int itemId)
        {
            //首先獲取LineItem資料
            var lineItemFromRepo = await _productRepository.GetShoppingCartByItemId(itemId);
            //先判斷存不存在
            if(lineItemFromRepo == null)
            {
                return BadRequest("購物車商品找不到");
            }
            _productRepository.DeleteShoppingCartItem(lineItemFromRepo);
            await _productRepository.SaveAsync();

            return NoContent();
        }

        [HttpPost("checkout")]
        [Authorize(AuthenticationSchemes ="Bearer")]
        public async Task<IActionResult> Checkout()
        {
            //1.獲得當前用戶
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("userId");

            //2.使用userId獲得購物車
            var shoppingCart = await _productRepository.GetShoppingCartByUserId(userId);

            int UserId = int.Parse(userId);

            //3.創建訂單
            var order = new Order()
            {
                UserId = UserId,
                State = OrderStateEnum.Pending,
                OrderItems = shoppingCart.ShoppingCartItems,
                CreateDateUTC = DateTime.UtcNow
            };

            //結算後將購物車清空
            shoppingCart.ShoppingCartItems = null;
            
            //4.保存數據
            await _productRepository.AddOrderAsync(order);
            await _productRepository.SaveAsync();

            return Ok(_mapper.Map<OrderDto>(order));

        }

    }
}
