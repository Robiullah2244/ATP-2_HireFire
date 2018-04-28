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

        IEnumerable<Buyer> GetByUserName(string UserName);

        bool Insert(Buyer buyer);
        bool Update(Buyer buyer);
        bool Delete(string UserName);


        
    }
}
