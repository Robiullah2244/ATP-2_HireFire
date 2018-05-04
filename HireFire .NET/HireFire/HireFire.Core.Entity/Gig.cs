using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Gig
    {
        public int Id { get; set; }
        public string SellerUserName { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfOrder { get; set; }

    }
}
