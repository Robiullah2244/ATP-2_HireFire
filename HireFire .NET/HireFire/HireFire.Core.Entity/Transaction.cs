using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class Transaction
    {
        public string SellerName { get; set; }
        public string BuyerName { get; set; }
        public int PromoCode { get; set; }
        public int GigId { get; set; }
    }
}
