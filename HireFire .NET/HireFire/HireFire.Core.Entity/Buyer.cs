using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Buyer 
    {
        [Key]
        public string UserName { get; set; }
        public DateTime JoiningDate { get; set; }
        
    }
}
