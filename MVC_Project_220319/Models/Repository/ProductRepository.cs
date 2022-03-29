using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public class ProductRepository : IProductRepository
    {
        private readonly MvcTestDbContext _context;

        public ProductRepository(MvcTestDbContext mvcTestDbContext)
        {
            _context = mvcTestDbContext;
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products;
        }

        public Product GetProductById(Guid id)
        {
            return _context.Products.FirstOrDefault(n => n.Id == id);
        }

        //public Product GetProductById(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    } 
}
