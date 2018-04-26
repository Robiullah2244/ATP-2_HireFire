using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class Message
    {
        public int Id { get; set; }
        public int ConversionNumber { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public string Text { get; set; }

    }
}
