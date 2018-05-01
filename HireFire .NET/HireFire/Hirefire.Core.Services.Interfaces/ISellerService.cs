using HireFire.Core.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ISellerService
    {
        IEnumerable<Seller> GetAll();//Only needed for showing the seller List from admin

        Seller GetByUserName(string userName);

        bool UpdateProfileByUserName(string userName, string name, string email, string languages);//Also have to update buyer table.

        bool UpdatePasswordByUserName(string userName, string newPassword);

        bool UpdateAccountByUserName(string userName, string bankName, string accountNumber);

        bool UpdateContactInfo(string userName, string workingHour, string district, string address, string postalCode, string mobileNumber);

        bool UpdateSkillByUserName(string userName, ArrayList skill);


        bool UpdateDescriptionByUserName(string userName,string description);
        bool InsertLanguageByUserName(string userName, string language);
        bool InsertSkillByUserName(string userName, string skill);

        bool Insert(Seller seller);
        bool Update(Seller seller);
        bool Delete(string userName);

    }
}
