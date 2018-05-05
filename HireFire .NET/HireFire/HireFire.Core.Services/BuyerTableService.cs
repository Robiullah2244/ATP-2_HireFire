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
        public IEnumerable<string> GetAllSellerNameList(IEnumerable<Transaction> transaction)
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
        public IEnumerable<dynamic> GetActiveWorkByUserName(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<dynamic> GetPendingWorkByUserName(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<dynamic> GetCompletedWorkByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
