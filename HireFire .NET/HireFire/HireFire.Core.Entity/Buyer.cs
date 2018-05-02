﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Buyer 
    {
        [Key]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }

        public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime LastActiveTimeInfo { get; set; }
        
    }
}
