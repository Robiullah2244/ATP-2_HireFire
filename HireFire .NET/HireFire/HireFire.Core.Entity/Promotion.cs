using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class Promotion
    {
        public int Id { get; set; }
        public string PromotionCode { get; set; }
        public int Percentage { get; set; }
        public int MaxAmount { get; set; }
    }
}
