using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Entity
{
    public class Seller
    {
        [Key]
        public string UserName { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int ReputationPoint { get; set; }
        public int WorkingHour { get; set; }

        //Account
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        //address
        public string District { get; set; }
        public string Address { get; set; }
        public int PostalCode { get; set; }
        public string MobileNumber { get; set; }

        //Education
        public string InstituteName { get; set; }
        public DateTime InstituteAttendFrom { get; set; }
        public DateTime InstituteAttendTo { get; set; }
        public string Degree { get; set; }
        public string Area { get; set; }
        

    }
}
