using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Task
    {
        public int Id { get; set; }
        //public int GigId { get; set; }
        public int OrderId { get; set; }
        public string TaskName { get; set; }
        public int Status { get; set; }  // Pending-->1    On Going-->2
        public DateTime Deadline { get; set; }
        public bool Approbation { get; set; }
        public string FileName { get; set; }

    }
}
