using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireFire.Core.Entity;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IBuyerService
    {
        IEnumerable<Buyer> GetAll();

        dynamic GetByUserName(string userName);

        bool Insert(Buyer buyer);
        bool UpdateProfileByUserName(string userName, string name, string email);//This update is from buyer page. This update will also 
                                                                                 //update seller page if the user is seller also.
        bool UpdatePasswordByUserName(string userName, string newPassword);

        bool Update(string userName, string name, string email, string newPassword);//This is for submit all changes button.

        bool Delete(string userName);

        IEnumerable<Buyer> NewUser();

        //int TotalSpend(string userName);



        
    }
}
