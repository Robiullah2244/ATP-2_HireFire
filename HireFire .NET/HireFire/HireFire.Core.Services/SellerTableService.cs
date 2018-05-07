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
    public class SellerTableService : ISellerTableService
    {
         DbContext _context;
         public SellerTableService(DbContext con)
        {
            _context = con;
        }
        public IEnumerable<Order> GetActiveWorkByUserName(string userName)
        {
            return (_context.Set<Order>().Where(b => b.SellerName == userName && b.Status == 2).OrderByDescending(b => b.Deadline).ToList());
        }
        public IEnumerable<Gig> GetAllGigInformationByOrderId(IEnumerable<Order> order)
        {
            List<Gig> GigList = new List<Gig>();
            foreach (var item in order)
            {
                var z = _context.Set<Gig>().Where(b => b.Id == item.GigId).FirstOrDefault();
                GigList.Add(z);
            }
            return GigList;
        }
        public IEnumerable<Order> GetPendingWorkByUserName(string uesrName)
        {
            return (_context.Set<Order>().Where(b => b.SellerName == uesrName && b.Status == 1).OrderByDescending(b => b.Deadline).ToList());

        }
        public IEnumerable<Order> GetCompletedWorkByUserName(string uesrName)
        {
            return (_context.Set<Order>().Where(b => b.SellerName == uesrName && b.Status == 3).OrderByDescending(b => b.Deadline).ToList());
        }

        public IEnumerable<Transaction> GetTransactionForCompletionDate(IEnumerable<Order> order)
        {
            List<Transaction> TransactionList = new List<Transaction>();
            foreach (var item in order)
            {
                var z = _context.Set<Transaction>().Where(b => b.OrderId == item.Id).FirstOrDefault();
                TransactionList.Add(z);
            }
            return TransactionList;
        }
        public IEnumerable<Transaction> GetTransaction(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetAllBuyerNameList(IEnumerable<Transaction> transaction)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetAllGigName(IEnumerable<Transaction> transaction)
        {
            throw new NotImplementedException();

        }
        public IEnumerable<string> GetAllSellerNameListByGig(IEnumerable<Gig> gig)
        {
            throw new NotImplementedException();

        }
        
    }
}
