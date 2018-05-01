using Hirefire.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireFire.Web.Mvc.Controllers
{
    public class OthersController : Controller
    {
        // GET: Others
         IUserAuthenticationService _userAuthenticationService;
         IMessengerService _messengerService;


        public OthersController(IUserAuthenticationService authenticationService, IMessengerService _messengerService)
        {
            _userAuthenticationService = authenticationService;
            this._messengerService = _messengerService;
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult ProceedToOrder()
        {
            return View();
        }

        public ActionResult OrderRequirements()
        {
            return View();
        }
        public ActionResult PlaceOrder()
        {
            return View();
        }
        public ActionResult ContactSeller()
        {
            return View();
        }
        public ActionResult Messenger()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
        public ActionResult PublicHome()
        {
            return View();
        }
        public ActionResult HomeWithOutSign_IN()
        {
            return View();
        }
        public ActionResult SignIN()
        {
            return View();
        }
        public ActionResult SignUP()
        {
            return View();
        }

        public ActionResult ProceedTo_OrderWithout_SignIN()
        {
            return View();
        }

        public void LoginTest()//UserAuthenticationServiceIsValidTest
        {
            var x = _userAuthenticationService.IsValid("tanim", "1");
            Response.Write(x);
            //Login test successful
        }
        public void LastMessageTest()
        {
            var x = _messengerService.GetLatestMessageByUesrName("tanim");
            Response.Write(x.Text);
        }
        //public void ContactListCheck()//Version 1
        //{
        //    var x = _messengerService.GetAllContactListByUserName("tanim");
        //    Response.Write("ConversionNum   FromUser    ToUser  Text<br/>");
        //    foreach (var x1 in x)
        //    {
        //        Response.Write(x1.ConversionNumber + "    " + x1.FromUser + "     " + x1.ToUser + "    " + x1.Text + "<br/>");
        //    }
        //}
        public void ContactListCheck()//Version 1
        {
            var x = _messengerService.GetAllContactListByUserName("tanim");
            Response.Write("Contact List<br/>");
            foreach (var x1 in x)
            {
                Response.Write(x1+"<br/>");
            }
        }

    }
}