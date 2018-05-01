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
        IEnumerable<dynamic> ActiveWorkByUserName(string uesrName);
        IEnumerable<dynamic> PendingWorkByUserName(string uesrName);
        IEnumerable<dynamic> CompletedWorkByUserName(string uesrName);
    }
}
