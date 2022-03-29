using MVC_Project_220322.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project_220319.Models
{
    public class User
    {
        [KeyAttribute]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }  //使用者編號

        //1.使用者帳號 信箱
        [Required]
        [EmailAddress]
        public string Account { get; set; }

        //2.使用者密碼
        [Required]
        public string Password { get; set; } //SHA256

        [Required]
        public string Salt { get; set; }    //加鹽

        //3.使用者姓名
        //姓名
        [Required]
        public string LastName { get; set; }  //姓

        [Required]
        public string FirstName { get; set; }  //名

        //5.電話
        [Required]
        [Phone]
        public string Phone { get; set; }

        //信箱驗證
        public bool Verification {get; set;}


        //身分別(角色權限) //一對多關係 //一個角色擁有多個使用者，一個使用者對應一個角色
        [ForeignKey("Role")]
        public int RoleId { get; set; }    
        public virtual Role Role { get; set; }


        //一對一關係 不包含信息 
        //廠商
        public virtual Firm Firm { get; set; }

        //管理員
        //public virtual Admin  Admini { get; set; }

        //會員
        public virtual Member Member { get; set; }
    }
}