﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    class User
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public int Type { get; set; }           //1-->Admin    2-->Buyer    3-->Seller
        public string Email { get; set; }     
        public string ImagePath { get; set; }
        public DateTime LastActiveTimeInfo { get; set; }

    }
}
