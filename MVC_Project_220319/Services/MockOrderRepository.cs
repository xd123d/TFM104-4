using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public class MockOrderRepository : IOrderRepository
    {
        private List<Order> _orders;

        public MockOrderRepository()
        {
            if (_orders == null)
            {
                InitializeOrder();

            }
        }
        private void InitializeOrder()
        {
            _orders = new List<Order>
            {
                //new Order{OrderId=1,OrderName="阿花",OrderDate=new DateTime(2022, 5, 13)},
                //new Order{OrderId=2,OrderName="大明",OrderDate=new DateTime(2022, 6, 13)},
                //new Order{OrderId=3,OrderName="阿王",OrderDate=new DateTime(2022, 7, 13)},

            };
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orders;
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }
    }
}
