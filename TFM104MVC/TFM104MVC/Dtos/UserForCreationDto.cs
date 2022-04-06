using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFM104MVC.Models;

namespace TFM104MVC.Dtos
{
    public class UserForCreationDto
    {
        public string Account { get; set; }         //1.使用者帳號 信箱

        public string Password { get; set; }        //2.使用者密碼 //SHA256

        public string LastName { get; set; }  //姓

        public string FirstName { get; set; }  //名

        public string Phone { get; set; }

        //信箱驗證
        public bool Verification { get; set; }

        public string RoleName { get; set; }

        //一對一關係 不包含信息 
        //廠商
        public virtual Firm Firms { get; set; }

        //管理員
        public virtual Admin Admins { get; set; }

        //會員
        public virtual Member Members { get; set; }
    }
}
