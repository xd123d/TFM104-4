using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using MVC_Project_220322.Models;

namespace MVC_Project_220319.Models
{
    public class MvcTestDbContext : DbContext
    {
        public MvcTestDbContext(DbContextOptions<MvcTestDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Orderdetail> Orderdetails { get; set; }
        public DbSet<CustomerRating> CustomerRatings { get; set; }


        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //設定初始化 種子資料庫
            var productJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Database/productV3.json");
            IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productJsonData);
            modelBuilder.Entity<Product>().HasData(products);

            //設定訂單明細 的 複合主鍵
            modelBuilder.Entity<Orderdetail>().HasKey(t => new { t.OrderId, t.ProductId });
        }
    }
}
