using System.Collections;
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
                targetSeller.Name = seller.Name;
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

        public bool UpdateDescriptionByUserName(string userName, string description)
        {
            throw new NotImplementedException();
        }

        public bool InsertLanguageByUserName(string userName, string language)
        {
            throw new NotImplementedException();
        }
        public bool InsertSkillByUserName(string userName, string skill)
        {
            throw new NotImplementedException();
        }

        public bool UpdateProfileByUserName(string userName, string name, string email, string languages)
            //Also have to update buyer table.
        {
            throw new NotImplementedException();
        }

        public bool UpdatePasswordByUserName(string userName, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool UpdateAccountByUserName(string userName, string bankName, string accountNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdateContactInfo(string userName, string workingHour, string district, string address, string postalCode,
            string mobileNumber)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSkillByUserName(string userName, ArrayList skill)
        {
            throw new NotImplementedException();
        }

        
    }
}
