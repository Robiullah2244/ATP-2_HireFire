using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
//using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Services
{
    public class AdminService : IAdminService
    {
        DbContext ctx;
        public AdminService(DbContext context)
        {
            ctx = context;
        }
        public IEnumerable<Admin> GetAll()
        {
            return ctx.Set<Admin>().ToList();
        }

        public Admin GetByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Admin buyer)
        {
            throw new NotImplementedException();
        }
        public bool Update(Admin buyer)
        {
            throw new NotImplementedException();
        }
        public bool Delete(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
