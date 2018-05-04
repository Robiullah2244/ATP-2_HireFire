using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Services
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        DbContext _context;

        public UserAuthenticationService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
        public User GetByUserName(string userName)
        {
            return _context.Set<User>().Where(b => b.UserName == userName).FirstOrDefault();
           // throw new NotImplementedException();
        }
        public bool Insert(User user)
        {
            try
            {
                _context.Set<User>().Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Update(User user)
        {
            throw new NotImplementedException();
        }
        public bool Delete(string userName)
        {
            throw new NotImplementedException();
        }

        public int IsValid(string userName, string password)// if valid then return type.. Return Zero for Invalid  ( Sign In purpose)
        {
            var targetUser= GetByUserName(userName);
            if (targetUser != null && (targetUser.Password.ToString() == password))
            {
                //int type = (int)(targetUser.Type);
                return targetUser.Type;//If valid return the user type
            }
            else
            {
                return 0;//That means user is not valid
            }
            //throw new NotImplementedException();
        }
    }
}
