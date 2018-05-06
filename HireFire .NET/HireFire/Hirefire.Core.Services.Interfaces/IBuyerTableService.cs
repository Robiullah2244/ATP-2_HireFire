using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IBuyerTableService
    {
        IEnumerable<dynamic> GetTopSeller(string userName);
        IEnumerable<Transaction> GetTransaction(string userName);
        IEnumerable<string> GetAllSellerNameList(IEnumerable<Transaction> transaction);//Seller Name will be found for GetAccountHistory 
        IEnumerable<string> GetAllGigName(IEnumerable<Transaction> transaction);//Gig Name will be found for GetAccountHistory 
        IEnumerable<Order> GetActiveWorkByUserName(string uesrName);
        IEnumerable<Gig> GetAllGigInformationByOrderId(IEnumerable<Order> order);
        IEnumerable<string> GetAllSellerNameListByGig(IEnumerable<Gig> gig);
        IEnumerable<Order> GetPendingWorkByUserName(string uesrName);
        IEnumerable<Order> GetCompletedWorkByUserName(string uesrName);
        IEnumerable<Transaction> GetTransactionForCompletionDate(IEnumerable<Order> order);
    }
}
