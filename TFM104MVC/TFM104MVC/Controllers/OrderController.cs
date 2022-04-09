using Microsoft.AspNetCore.Mvc;

namespace TFM104MVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Manage()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
