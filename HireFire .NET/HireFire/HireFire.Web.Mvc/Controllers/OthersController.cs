using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using HireFire.Web.Mvc.Models;
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
        IGigService _gigService;
        ISellerService _sellerService;
        IOrderService _OrderService;


        public OthersController(IBuyerService service, IUserAuthenticationService userAuthenticationService,IGigService gigService,ISellerService sellerService,IOrderService OrderService)
        {
            _buyerService = service;
            _userAuthenticationService = userAuthenticationService;
            _gigService = gigService;
            _sellerService = sellerService;
            _OrderService = OrderService;
        }
        public ActionResult Home(int categoryId)
        {

            var gigs = _gigService.GetByCategoryId(categoryId);
            var sellers = _sellerService.GetAll();
            ViewBag.gigs = gigs;
            ViewBag.sellers = sellers;
            ViewBag.categoryId = categoryId;
            return View();
        }
        public ActionResult ProceedToOrder(int gigId)
        {
            var gig = _gigService.GetByGigId(gigId);
            var seller = _sellerService.GetByUserName(gig.SellerUserName);
            var order = _OrderService.GetByGigId(gigId);
            ViewBag.gig = gig;
            ViewBag.seller = seller;
            ViewBag.order = order;
            
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
        public ActionResult SignIN(SignInViewModel user)
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
        [HttpPost, ActionName("SignUP")]
        public ActionResult SignUP(SignUpViewModel user)
        {
               
            if(ModelState.IsValid)
            { 
                ReturnUser r = new ReturnUser();
                var x = _userAuthenticationService.Insert(r.UserTypeBuyer(user));
               
                if (!x)
                {
                    ModelState.AddModelError("UserName", "UserName Already Exist");
                }
                else
                {
                    var y = _buyerService.Insert(r.BuyerUser(user));
                    Session["userName"] = user.UserName;
                    return RedirectToAction("Profile", "Buyer");
                }
            }
            return View(user);
        }
        public ActionResult ProceedTo_OrderWithout_SignIN()
        {
            return View();
        }

        



    }
}