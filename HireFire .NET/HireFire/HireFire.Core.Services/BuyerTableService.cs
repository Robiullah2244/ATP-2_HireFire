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
    public class BuyerTableService : IBuyerTableService
    {
        DbContext _context;
        public BuyerTableService(DbContext con)
        {
            _context = con;
        }
        public IEnumerable<dynamic> GetTopSeller(string userName)
        {

            throw new NotImplementedException();
        }
        public IEnumerable<Transaction> GetTransaction(string userName)
        {
            return(_context.Set<Transaction>().Where(b => b.BuyerName == userName).OrderByDescending(b=>b.Date).ToList());
        }
        public IEnumerable<string> GetAllGigName(IEnumerable<Transaction> transaction)
        {
            List<int> GigId = new List<int>();
            List<string> GigName = new List<string>();
            foreach (var item in transaction)
            {
                var z = _context.Set<Order>().Where(b => b.Id == item.OrderId).FirstOrDefault();
                GigId.Add(z.GigId);
            }
            foreach (var item in GigId)
            {
                var y = _context.Set<Gig>().Where(b => b.Id == item).FirstOrDefault();
                GigName.Add(y.Title);
            }
            return GigName;
        }
        public IEnumerable<string> GetAllSellerNameList(IEnumerable<Transaction> transaction)//Account History Page
        {
            List<string> sellerName = new List<string>();
            foreach (var item in transaction)
            {
                var z = _context.Set<Seller>().Where(b => b.UserName == item.SellerName).FirstOrDefault();
                sellerName.Add(z.Name);
            }
            return sellerName;
        }
        //public IEnumerable<dynamic> GetAccountHistory(string userName)
        //{
        //    var x = _context.Set<Transaction>().Where(b => b.BuyerName == userName).ToList();
        //    List<int> GigId = new List<int>();
        //    List<string> GigName = new List<string>();
        //    foreach (var item in x)
        //    {
        //        var z = _context.Set<Order>().Where(b => b.Id == item.OrderId).FirstOrDefault();
        //        GigId.Add(z.GigId);
        //    }
        //    foreach (var item in GigId)
        //    {
        //        var y = _context.Set<Gig>().Where(b => b.Id == item).FirstOrDefault();
        //        GigName.Add(y.Title);
        //    }
        //    var obj = new List<dynamic>();
        //    obj.Add(x);
        //    obj.Add(GigName);
        //    return obj;
        //    //throw new NotImplementedException();
        //}
        public IEnumerable<Order> GetActiveWorkByUserName(string userName)
        {
            return (_context.Set<Order>().Where(b => b.BuyerName == userName && b.Status==2).OrderByDescending(b => b.Deadline).ToList());
            //throw new NotImplementedException();
        }
        public IEnumerable<Gig> GetAllGigInformationByOrderId(IEnumerable<Order> order)//Get All other information using the order table for Active,Pending,Completed Works
        {
            List<Gig> GigList = new List<Gig>();
            foreach (var item in order)
            {
                var z = _context.Set<Gig>().Where(b => b.Id == item.GigId).FirstOrDefault();
                GigList.Add(z);
            }
            return GigList;
        }
        public IEnumerable<string> GetAllSellerNameListByGig(IEnumerable<Gig> gig)//Account History Page
        {
            List<string> sellerName = new List<string>();
            foreach (var item in gig)
            {
                var z = _context.Set<Seller>().Where(b => b.UserName == item.SellerUserName).FirstOrDefault();
                sellerName.Add(z.Name);
            }
            return sellerName;
        }
        public IEnumerable<Order> GetPendingWorkByUserName(string userName)
        {
            return (_context.Set<Order>().Where(b => b.BuyerName == userName && b.Status == 1).OrderByDescending(b => b.Deadline).ToList());

        }
        public IEnumerable<Order> GetCompletedWorkByUserName(string userName)
        {
            return (_context.Set<Order>().Where(b => b.BuyerName == userName && b.Status == 3).OrderByDescending(b => b.Deadline).ToList());
        }
        public IEnumerable<Transaction> GetTransactionForCompletionDate(IEnumerable<Order> order)//Get Completion Date using the order table for Completed Works
        {
            List<Transaction> TransactionList = new List<Transaction>();
            foreach (var item in order)
            {
                var z = _context.Set<Transaction>().Where(b => b.OrderId == item.Id).FirstOrDefault();
                TransactionList.Add(z);
            }
            return TransactionList;
        }
    }
}
