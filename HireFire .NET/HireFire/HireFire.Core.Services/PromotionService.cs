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
    class PromotionService : IPromotionService
    {

        DbContext _context;

        public PromotionService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Promotion> GetAll()
        {
            return _context.Set<Promotion>().ToList();
        }

        public Language GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public bool Update(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
