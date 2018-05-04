using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireFire.Web.Mvc.Models
{
    public class ReturnUser
    {
        public Buyer BuyerUser(SignUpViewModel user)
        {
            
            Buyer s = new Buyer();
            s.UserName=user.UserName;
            s.Name = user.Name;
             s.JoiningDate = DateTime.Now;
            s.Email = user.Email;
            s.ImagePath = "default.jpg";
            s.LastActiveTimeInfo = DateTime.Now;
            s.LogInStatus = true;
            return s;
        }
        public User UserTypeBuyer(SignUpViewModel user){
            User s=new User();
            s.UserName=user.UserName;
            s.Password=user.Password;
            s.Type=1;
            return s;
        }
    }
}