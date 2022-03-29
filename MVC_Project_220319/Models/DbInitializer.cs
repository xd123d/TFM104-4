//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MVC_Project_220319.Models
//{
//    public static class DbInitializer
//    {
//        public static void Seed(MvcTestDbContext context)
//        {
//            if (context.Products.Any())
//            {
//                return;
//            }

//            context.AddRange
//            (
//                new Product{ProductName="台北一日遊",Description="遊山玩水",OriginalPrice=1000,CreateDate=new DateTime(2008, 5, 13),Status="未審核"},
//                new Product{ProductName="台中一日遊",Description="請你吃慶記",OriginalPrice=3000,CreateDate=new DateTime(2019, 6, 18),Status="已上架"},
//                new Product{ProductName="花蓮一日遊",Description="花蓮王帶你玩",OriginalPrice=8888,CreateDate=new DateTime(2020, 7, 18),Status="已上架"},
//                new Product{ProductName="高雄一日遊",Description="發大財",OriginalPrice=10000,CreateDate=new DateTime(2018, 5, 18),Status="已上架"}
//            );

//            context.SaveChanges();

//        }
//    }
//}
