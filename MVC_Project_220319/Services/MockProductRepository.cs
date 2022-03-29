//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MVC_Project_220319.Models
//{
//    public class MockProductRepository : IProductRepository
//    {
//        private List<Product> _products;

//        public MockProductRepository()
//        {
//            if (_products == null)
//            {
//                InitializeProduct();
//            }
//        }

//        private void InitializeProduct()
//        {
//            _products = new List<Product>
//            {
//                new Product{ProductId=1,ProductName="台北一日遊",Description="遊山玩水",OriginalPrice=1000,CreateDate=new DateTime(2008, 5, 13),Status="未審核"},
//                new Product{ProductId=1,ProductName="高雄一日遊",Description="發大財",OriginalPrice=10000,CreateDate=new DateTime(2018, 5, 18),Status="已上架"}
//            };

//        }

//        public IEnumerable<Product> GetAllProducts()
//        {
//            return _products;
//        }

//        public Product GetProductById(int id)
//        {
//            return _products.FirstOrDefault(n => n.ProductId == id);
//        }

//        public void AddProduct(Product product)
//        {
//            _products.Add(product);

//        }
//    }
//}
