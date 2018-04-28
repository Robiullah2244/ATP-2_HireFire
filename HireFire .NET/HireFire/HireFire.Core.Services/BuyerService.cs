using Hirefire.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HireFire.Core.Entity;
using System.Data.Entity;

namespace HireFire.Core.Services
{
    public class BuyerService : IBuyerService
    {
        DbContext _context;

        public BuyerService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Buyer> GetAll()
        {
            return _context.Set<Buyer>().ToList();
        }
    
        public Buyer GetByUserName(string userName)
        {
            return _context.Set<Buyer>().Where(c => c.UserName == userName).FirstOrDefault();
            //return _context.Set<Buyer>().ToList();
        }

        public bool Insert(Entity.Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entity.Buyer buyer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
