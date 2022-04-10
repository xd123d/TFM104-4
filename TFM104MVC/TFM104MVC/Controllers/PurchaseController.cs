using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using TFM104MVC.Dtos;
using TFM104MVC.Services;

namespace TFM104MVC.Controllers
{
    public class PurchaseController : Controller
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public PurchaseController(IProductRepository productRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _environment = webHostEnvironment;
        }

        public IActionResult Booking()
        {
            //把商品id從session拿出來
            var pid= HttpContext.Session.GetString("pid");

            //測試一下有沒有拿到對的id
            //System.Console.WriteLine(pid); //確定有拿到 我好棒

            var productFromRepo =  _productRepository.GetProductAsync(Guid.Parse(pid));
            var productDto = _mapper.Map<ProductDto>(productFromRepo);
            var x = productDto.Price;
            //測試一下拿到值要幹嘛
            Console.WriteLine(x);

            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

    }
}
