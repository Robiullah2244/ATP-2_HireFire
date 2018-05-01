using HireFire.Core.Entity;
using System;
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

        bool UpdateDescriptionByUserName(string userName,string description);
        bool InsertLanguageByUserName(string userName, string language);
        bool InsertSkillByUserName(string userName, string skill);
        bool Insert(Seller seller);
        bool Update(Seller seller);
        bool Delete(string userName);

    }
}
