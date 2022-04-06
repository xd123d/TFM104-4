using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFM104MVC.Models;

namespace TFM104MVC.Services
{
    public interface IAuthenticateRepository
    {
        User CheckUser(string account , string password);
        User AccountCheck(string account);

        void AddUser(User user);

        bool Save();
    }
}
