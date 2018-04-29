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
        IEnumerable<Seller> GetAll();

        Seller GetByUserName(string userName);

        bool Insert(Seller seller);
        bool Update(Seller seller);
        bool Delete(string userName);

    }
}
