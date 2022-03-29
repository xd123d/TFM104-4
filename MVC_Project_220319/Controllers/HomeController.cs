using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_Project_220319.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MVC_Project_220319.ViewModels;


namespace MVC_Project_220319.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private IOrderRepository _orderRepository;


        public HomeController(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            //var products = _productRepository.GetAllProducts();
            var viewModel = new HomeViewModel()
            {
                Products = _productRepository.GetAllProducts().ToList(),
                Orders = _orderRepository.GetAllOrders().ToList(),
            };
            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
