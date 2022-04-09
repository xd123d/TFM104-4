using Microsoft.AspNetCore.Mvc;

namespace TFM104MVC.Controllers
{
    public class ProductViewController : Controller
    {
        //全部商品列表
        public IActionResult productlist()
        {
            return View();
        }

        //單一商品
        public IActionResult product()
        {
            return View();
        }

    }
}
