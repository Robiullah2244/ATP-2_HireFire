using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace HireFire.Web.Mvc.Models
{
    public class BuyerRegistrationViewModel
    {
        [DisplayName("User Name")]
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime JoiningDate { get; set; }

        public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime LastActiveTimeInfo { get; set; }
    }
}