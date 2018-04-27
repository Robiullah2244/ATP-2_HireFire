﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class Gig
    {
        public int Id { get; set; }
        public string SellerUserName { get; set; }
        public sbyte Title { get; set; }
        public string CategoryId { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public int NumberOfOrder { get; set; }

    }
}