using Microsoft.AspNetCore.Mvc;

namespace TFM104MVC.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult booking()
        {
            return View();
        }

        public IActionResult cart()
        {
            return View();
        }

    }
}
