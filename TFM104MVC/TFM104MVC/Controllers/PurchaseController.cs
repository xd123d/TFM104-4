using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TFM104MVC.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Booking()
        {
            //把商品id從session拿出來
            var pid= HttpContext.Session.GetString("pid");
            //測試一下有沒有拿到對的id
            System.Console.WriteLine(pid);
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

    }
}
