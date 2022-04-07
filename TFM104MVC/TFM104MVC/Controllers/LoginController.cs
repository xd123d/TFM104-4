using Microsoft.AspNetCore.Mvc;

namespace TFM104MVC.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
