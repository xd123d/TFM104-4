using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Project_220319.Models;

namespace MVC_Project_220319.ViewModels
{
    public class HomeViewModel
    {
        public IList<Product> Products { get; set; }
        public IList<Order> Orders { get; set; }
    }
}
