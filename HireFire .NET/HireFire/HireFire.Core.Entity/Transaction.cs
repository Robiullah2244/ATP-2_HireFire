using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public int BuyerPaid { get; set; }
        public string SellerName { get; set; }
        public float SellerEarned { get; set; }
        public int OrderId { get; set; }
        public int PromotionId { get; set; }
        public float HireFireProfit { get; set; }
        public DateTime Date { get; set; }
    }
}
