using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class User
    {
        [Key]
        public string UserName { get; set; } 
        public string Password { get; set; }
        public int Type { get; set; }           //1-->Admin    2-->Buyer    3-->Seller
        

    }
}
