using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class TaskComment
    {
        public int Id { get; set; }
        public int GigId { get; set; }
        public int OrderId { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public string Reply { get; set; }
    }
}
