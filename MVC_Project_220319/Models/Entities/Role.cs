using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC_Project_220319.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; } //權限編號
        [Required]
        public string Name { get; set; }   //權限名稱

        //一個角色擁有多個使用者
        public virtual ICollection <User> Users { get; set; }  
    }
}