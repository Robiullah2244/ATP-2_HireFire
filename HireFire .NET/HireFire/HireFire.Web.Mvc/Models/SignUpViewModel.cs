using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HireFire.Web.Mvc.Models
{
    public class SignUpViewModel
    {
       
        //public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [DisplayName("Re-Type Password")]
        [Compare("Password")]
        public string ReTypePassword { get; set; }
        [Required]
        public string Language { get; set; }

        //[Key]
        [DisplayName("User Name")]
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime JoiningDate { get; set; }
        [Required]
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public DateTime LastActiveTimeInfo { get; set; }
        public bool LogInStatus { get; set; }

    }
}