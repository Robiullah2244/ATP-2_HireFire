using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ISellerTableService
    {
        IEnumerable<Transaction> GetTransaction(string userName);
        IEnumerable<string> GetAllBuyerNameList(IEnumerable<Transaction> transaction);
        IEnumerable<string> GetAllGigName(IEnumerable<Transaction> transaction); 
        IEnumerable<Order> GetActiveWorkByUserName(string uesrName);
        IEnumerable<Gig> GetAllGigInformationByOrderId(IEnumerable<Order> order);
        IEnumerable<string> GetAllSellerNameListByGig(IEnumerable<Gig> gig);
        IEnumerable<Order> GetPendingWorkByUserName(string uesrName);
        IEnumerable<Order> GetCompletedWorkByUserName(string uesrName);
        IEnumerable<Transaction> GetTransactionForCompletionDate(IEnumerable<Order> order);
        //IEnumerable<dynamic> TopBuyer();
        //IEnumerable<dynamic> ActiveWorkByUserName(string sellerUesrName);
        //IEnumerable<dynamic> PendingWorkByUserName(string sellerUesrName);
        //IEnumerable<dynamic> CompletedWorkByUserName(string sellerUesrName);
    }
}
