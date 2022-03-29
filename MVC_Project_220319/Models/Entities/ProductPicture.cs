using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public class ProductPicture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } //圖片id

        [Required]
        public string Url { get; set; } //圖片路徑

        [ForeignKey("Product")] //外來鍵
        public Guid ProductId { get; set; } //對應商品id
        public virtual Product Product { get; set; }

    }
}
