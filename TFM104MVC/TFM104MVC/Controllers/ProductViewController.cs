using Microsoft.AspNetCore.Http;
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
        public IActionResult product([FromRoute] int id)
        {
            HttpContext.Session.SetString("camping_area_id", id.ToString());
            HttpContext.Session.GetString("camping_area_id");
            //Convert.ToInt32()

            return View();
        }

    }
}
