using Hirefire.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireFire.Core.Entity;
using System.Data.Entity;

namespace HireFire.Core.Services
{
    public class BuyerService : IBuyerService
    {
        DbContext _context;

        public BuyerService(DbContext context)
        {
            _context = context;
        }



        public IEnumerable<Buyer> GetAll()
        {
            return _context.Set<Buyer>().ToList();
        }
    


        public Buyer GetByUserName(string userName)
        {
            return _context.Set<Buyer>().Where(b => b.UserName == userName).FirstOrDefault();
            //return _context.Set<Buyer>().ToList();
        }



        public bool Insert(Buyer buyer)
        {
            try
            {
                _context.Set<Buyer>().Add(buyer);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool Update(Buyer buyer)
        {
            try
            {
                var targetBuyer= _context.Set<Buyer>().Where(b => b.UserName == buyer.UserName).FirstOrDefault();
                targetBuyer.Name = buyer.Name;
                targetBuyer.Email = buyer.Email;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }



        public bool Delete(string userName)
        {
            try
            {
                var targetBuyer = _context.Set<Buyer>().Where(b => b.UserName == userName).FirstOrDefault();
                _context.Set<Buyer>().Remove(targetBuyer);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public IEnumerable<Buyer> NewUser()
        {
            throw new NotImplementedException();
        }


        public bool UpdateProfileByUserName(string userName, string name, string email)
        {
            throw new NotImplementedException();
        }
        

        public bool UpdatePasswordByUserName(string userName, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
