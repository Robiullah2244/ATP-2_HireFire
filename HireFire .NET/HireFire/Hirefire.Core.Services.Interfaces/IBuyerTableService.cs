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
        IEnumerable<dynamic> TopSeller();
        IEnumerable<dynamic> ActiveWorkByUserName(string buyerUesrName);
        IEnumerable<dynamic> PendingWorkByUserName(string buyerUesrName);
        IEnumerable<dynamic> CompletedWorkByUserName(string buyerUesrName);
    }
}
