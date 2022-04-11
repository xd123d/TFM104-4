using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TFM104MVC.Controllers
{
    public class ProductViewController : Controller
    {
        //全部商品列表
        public IActionResult ProductList()
        {
            return View();
        }

        //單一商品
        public IActionResult Product([FromRoute] Guid id)  //商品頁後面接商品id
        {
            //把商品id存進session裡面，準備之後傳到其他地方(訂購頁,購物車 etc...)用
            HttpContext.Session.SetString("pid", id.ToString());

            //HttpContext.Session.GetString("camping_area_id");
            //Convert.ToInt32()

            return View();
        }

    }
}
