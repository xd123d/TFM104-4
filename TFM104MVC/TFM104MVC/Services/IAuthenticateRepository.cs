using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFM104MVC.Models;

namespace TFM104MVC.Services
{
    public interface IAuthenticateRepository
    {
<<<<<<< HEAD
        User CheckUser(string account,string password);
=======
        User CheckUser(string account , string password);
>>>>>>> unity1
        User AccountCheck(string account);

        void AddUser(User user);

        bool Save();
    }
}
