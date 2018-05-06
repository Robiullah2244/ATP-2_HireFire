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
    public class GigService : IGigService
    {
        DbContext _context;
        public GigService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Entity.Gig> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Gig> GetAllByUserName(string sellerUserName)
        {
            return _context.Set<Gig>().Where(c => c.SellerUserName == sellerUserName);
        }

        public IEnumerable<Entity.Gig> GetTopGigsByUserName(string sellerUserName)
        {
            throw new NotImplementedException();
        }

        public Gig GetByGigId(int gigId)
        {
            return _context.Set<Gig>().Where(c => c.Id == gigId).SingleOrDefault();
            
        }

        public IEnumerable<Entity.Gig> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Entity.Gig gig)
        {
            throw new NotImplementedException();
        }

        public bool Update(Entity.Gig gig)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public string SearchSuggestion(string searchValue, string searchBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Gig> GetBysearchValue(string searchValue, string searchBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Gig> GetBysearchValueByPrice(string searchValue, int minimum, int maximum)
        {
            throw new NotImplementedException();
        }

        public string SearchSuggestionByPrice(string searchValue, int minimum, int maximum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gig> GetByCategoryId(int categoryId)
        {
            return _context.Set<Gig>().Where(c => c.CategoryId == categoryId);
        }

        public int CountByUserName(string userName)
        {
            return _context.Set<Gig>().Where(c => c.SellerUserName == userName).Count();
        }

        public IEnumerable<Gig> GetTopGigByUserName(string sellerUserName)
        {
            //_context.Set<Order>().Where()
            //return _context.Set<Gig>().Where(c => c.SellerUserName == sellerUserName).OrderBy(c=>c.)
                throw new NotImplementedException();
        }
    }
}
