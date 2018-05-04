using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
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
        IBuyerService _buyerService;
        IUserAuthenticationService _userAuthenticationService;


        public OthersController(IBuyerService service, IUserAuthenticationService userAuthenticationService)
        {
            _buyerService = service;
            _userAuthenticationService = userAuthenticationService;
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
        [HttpPost]
        public ActionResult SignIN(User user)
        {
            if (ModelState.IsValid)
            {
                int x=_userAuthenticationService.IsValid(user.UserName, user.Password);
                if (x == 0)
                {
                    ModelState.AddModelError("UserName", "Check your userName");
                    ModelState.AddModelError("Password", "Check your password");
                    return View(user);
                }
                else
                {
                    Session["userName"]=user.UserName;
                    if (x == 1)
                    {
                        return RedirectToAction("Dashboard", "Admin");//, new { @userName = user.UserName });
                    }
                    else if (x == 2)
                    {
                        return RedirectToAction("Profile", "Buyer");//, new { @userName = user.UserName });
                    }
                    else
                    {
                        return RedirectToAction("Profile", "Seller");//, new { @userName = user.UserName });
                    }
                }
            }
            return View(user);
        }
        [HttpGet]
        public ActionResult SignUP()
        {
            return View();
        }
        [HttpPost,ActionName("SignUP")]
        public ActionResult SignUP(Buyer buyer, string password, string Re_TypePassword)
        {
            //var x = _buyerService.Insert(new Buyer { UserName = "zzz" , JoiningDate = DateTime.Now, Email = "sdsfc", ImagePath = "scsd", LastActiveTimeInfo = DateTime.Now, Name = "Robi" });
            //Response.Write(x);
            //Response.Write(buyer.UserName + "<br/>" + buyer.Name + "<br/>" + buyer.Email + "<br/>" + "password" + password);
            var x = _buyerService.Insert(new Buyer { UserName=buyer.UserName, JoiningDate=DateTime.Now.Date,Email=buyer.Email, LastActiveTimeInfo=DateTime.Now,Name=buyer.Name});
            //var x = _buyerService.Insert(buyer);
            Response.Write(x);
            if (x)
            {
                return RedirectToAction("Profile", "Buyer", new { @userName = buyer.UserName });
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult ProceedTo_OrderWithout_SignIN()
        {
            return View();
        }

        



    }
}