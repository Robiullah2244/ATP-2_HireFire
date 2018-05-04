using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireFire.Web.Mvc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        IUserAuthenticationService _userAuthenticationService;
        IMessengerService _messengerService;

        public TestController(IUserAuthenticationService authenticationService, IMessengerService _messengerService)
        {
            _userAuthenticationService = authenticationService;
            this._messengerService = _messengerService;
        }
        public ActionResult Test()
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
                Response.Write(x1 + "<br/>");
            }
        }

        public void ShowAllMessageCommunicationWithParticularUserTest()
        {
            var x = _messengerService.GetAllMessage("rakib", "tanim");
            Response.Write("ConversionNum   FromUser    ToUser  Text<br/>");
            foreach (var x1 in x)
            {
                Response.Write(x1.ConversionNumber + "    " + x1.FromUser + "     " + x1.ToUser + "    " + x1.Text + "<br/>");
            }
        }

        public void InsertMessageTest()
        {
            var x = _messengerService.Insert("Imail", "ASS  ", "aaa");
            Response.Write(x);
        }

    }
}