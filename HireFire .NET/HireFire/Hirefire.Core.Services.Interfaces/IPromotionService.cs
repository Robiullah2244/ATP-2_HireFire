using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IPromotionService
    {
        IEnumerable<Promotion> GetAll();

        Language GetById(int id);

        bool Insert(Promotion promotion);
        bool Update(Promotion promotion);
        bool Delete(int id);
    }
}
