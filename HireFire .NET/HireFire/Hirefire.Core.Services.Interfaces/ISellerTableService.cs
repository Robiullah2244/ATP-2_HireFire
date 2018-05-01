using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ISellerTableService
    {
        IEnumerable<dynamic> TopBuyer();
        IEnumerable<dynamic> ActiveWorkByUserName(string sellerUesrName);
        IEnumerable<dynamic> PendingWorkByUserName(string sellerUesrName);
        IEnumerable<dynamic> CompletedWorkByUserName(string sellerUesrName);
    }
}
