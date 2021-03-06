﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireFire.Web.Mvc.Models
{
    public class SignInViewModel
    {
        //[Key]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int Type { get; set; }           //1-->Admin    2-->Buyer    3-->Seller
    }
}