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
    public class SkillService : ISkillService
    {
        DbContext _context;
        public SkillService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Skill> GetByUserName(string userName)
        {
            return _context.Set<Skill>().Where(l => l.UserName == userName);

        }

        public bool Insert(Skill skill)
        {
            try
            {
                _context.Set<Skill>().Add(skill);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        // bool Update(Skill seller);
        public bool Delete(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
