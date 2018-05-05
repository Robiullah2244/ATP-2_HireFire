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
        IEnumerable<string> GetAllGigName(IEnumerable<Transaction> transaction);//Gig Name will be found for GetAccountHistory 
        IEnumerable<dynamic> GetActiveWorkByUserName(string uesrName);
        IEnumerable<dynamic> GetPendingWorkByUserName(string uesrName);
        IEnumerable<dynamic> GetCompletedWorkByUserName(string uesrName);
        IEnumerable<string> GetAllSellerNameList(IEnumerable<Transaction> transaction);
    }
}
