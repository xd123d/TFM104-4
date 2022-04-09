using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TFM104MVC.Dtos
{
    public class LineItemDto
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int? ShoppingCartId { get; set; }
        //public int? OrderId { get; set; }
        public decimal OriginalPrice { get; set; }
        public double? DiscountPersent { get; set; }
    }
}
