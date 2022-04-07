using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFM104MVC.Models;

namespace TFM104MVC.Services
{
    public class AuthenticateRepository : IAuthenticateRepository
    {
        private AppDbContext _context;
        public AuthenticateRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public User AccountCheck(string account)
        {
            return _context.Users.FirstOrDefault(x => x.Account == account);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public User CheckUser(string account,string password)
        {
            return _context.Users.FirstOrDefault(x => x.Account == account && x.Password == password);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
