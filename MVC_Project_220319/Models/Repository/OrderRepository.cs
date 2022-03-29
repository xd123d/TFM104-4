using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MvcTestDbContext _context;

        public OrderRepository(MvcTestDbContext mvcTestDbContext)
        {
            _context = mvcTestDbContext;
        }

        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();

        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _context.Orders;
        }
    }
}
