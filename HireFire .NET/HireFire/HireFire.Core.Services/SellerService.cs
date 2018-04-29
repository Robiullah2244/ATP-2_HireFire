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
    public class SellerService:ISellerService
    {
         DbContext _context;

        public SellerService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Seller> GetAll()
        {
            return _context.Set<Seller>().ToList();
        }
    
        public Seller GetByUserName(string userName)
        {
            return _context.Set<Seller>().Where(c => c.UserName == userName).FirstOrDefault();
        }

        public bool Insert(Seller seller)
        {
            try
            {
                _context.Set<Seller>().Add(seller);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Seller seller)
        {
            try
            {
                string userName = seller.UserName.ToString();
                var targetSeller = GetByUserName(userName);
                targetSeller.UserName = seller.Name;
                targetSeller.Email = seller.Email;
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
                var targetSeller = GetByUserName(userName);
                _context.Set<Seller>().Remove(targetSeller);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
