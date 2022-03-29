using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts(); //獲得所有旅遊商品
        Product GetProductById(Guid id); //依照id 拿到特定旅遊商品

        void AddProduct(Product product);
    }
}
