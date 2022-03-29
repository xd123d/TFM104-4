using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_220319.Models
{
    public class Firm
    {
        [Key]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }


        public string TaxId { get; set; }   //公司統編
        public string Name { get; set;} //公司名稱
    }
}