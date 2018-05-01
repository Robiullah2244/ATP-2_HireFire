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
        bool UpdateProfileByUserName(string userName, string name, string email);
        bool UpdatePasswordByUserName(string userName, string newPassword);
        bool Delete(string userName);

        IEnumerable<Buyer> NewUser();

        //int TotalSpend(string userName);



        
    }
}
