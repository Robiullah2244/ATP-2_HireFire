using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ISkillService
    {
        IEnumerable<Skill> GetByUserName(string userName);

        Buyer GetById(int id);

        bool Insert(Skill skill);
        bool Update(Skill seller);
        bool Delete(string userName);
    }
}
