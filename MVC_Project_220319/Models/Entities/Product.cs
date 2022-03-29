using MVC_Project_220322.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Project_220319.Models
{
    public class Product
    {
        [KeyAttribute]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } //商品編號

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } //商品名稱

        [Required]
        [MaxLength(1500)]
        public string Description { get; set; } //商品敘述

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OriginalPrice { get; set; } //商品原價

        [Range(0.0, 1.0)]
        public double? DiscountPersent { get; set; } //商品折扣(廠商)

        [Required]
        public DateTime CreateDate { get; set; } //建立日期
        [Required]
        public DateTime UpdateTime { get; set; } //更新時間
        [Required]
        public DateTime DepartureTime { get; set; } //出發日期

        public TravelDays? TravelDays { get; set; } //旅遊天數

        [MaxLength(1500)]
        public string Notes { get; set; } //商品備註

        [Required]
        public ProductStatus ProductStatus { get; set; } //商品狀態
        //public string Features { get; set; } //商品特色

        [Required]
        public TripType TripType { get; set; }  //商品分類

        [Required]
        public Region Region { get; set; } //地區分類

        public virtual ICollection<CustomerRating> CustomerRatings { get; set; } //商品評價
            = new List<CustomerRating>();
        //一個商品擁有多個評價

        public virtual ICollection<ProductPicture> ProductPictures { get; set; }
            = new List<ProductPicture>();
        //一對多 商品 對 多個商品圖

        public virtual  ICollection <Orderdetail> Orderdetails { get; set; }
        //訂單與商品多對多 延伸出的關係   //一個商品擁有多個訂單明細
    }
}
