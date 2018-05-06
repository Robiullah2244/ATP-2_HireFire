using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int GigId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Deadline { get; set; }
        public string BuyerName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public int Status { get; set; }  //Pending-->1   Active-->2    Completed-->3
        public string Feedback { get; set; }
        public int Rating { get; set; }
        public string SellerName { get; set; }

    }
}
