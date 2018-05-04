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
    public class OrderService : IOrderService
    {
        DbContext _context;
        public OrderService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>();
        }

        public Order GetById(int id)
        {
            return _context.Set<Order>().Where(o => o.Id == id).SingleOrDefault();
        }

        public Order MostPopularGig()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetByGigId(int gigId)
        {
            return _context.Set<Order>().Where(o => o.GigId == gigId);
        }
    }
}
