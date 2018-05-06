using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using HireFire.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

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
        ILanguageService _languageService;
        ITransactionService _transactionService;


        public OthersController(ILanguageService _languageService,IBuyerService service, IUserAuthenticationService userAuthenticationService,IGigService gigService,ISellerService sellerService,IOrderService OrderService, ITransactionService transactionService)
        {
            _buyerService = service;
            _userAuthenticationService = userAuthenticationService;
            _gigService = gigService;
            _sellerService = sellerService;
            _OrderService = OrderService;
            this._languageService = _languageService;
            _transactionService = transactionService;
        }
        public ActionResult Home(int categoryId = 1)
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

        public ActionResult OrderRequirements(int gigId)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("SignIn");
            }
            ViewBag.gigId = gigId;
            return View();
        }


        [HttpPost, ActionName("OrderRequirements")]
        public ActionResult OrderRequirementsPost(DateTime deadline, string requirements, int gigId)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("SignIn");
            }
            Session["deadline"] = deadline;
            Session["requirements"] = requirements;
            //Response.Write(Session["deadline"]);
            return RedirectToAction("PlaceOrder", new { gigId = gigId });
            //return View();
        }

        [HttpGet]
        public ActionResult PlaceOrder(int gigId)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("SignIn");
            }
            var gig = _gigService.GetByGigId(gigId);
            ViewBag.Title = gig.Title;
            ViewBag.Price = gig.Price;
            ViewBag.ProcessingFee = gig.Price * 10 / 100;
            ViewBag.TotalFee = gig.Price + ViewBag.ProcessingFee;
            ViewBag.Category = gig.CategoryId;

            ViewBag.OrderNumber = _OrderService.GetLatestOrderNumber();

            Seller seller = _sellerService.GetByUserName("Robi");
            ViewBag.Name = seller.Name;
            ViewBag.Level = seller.Level;
            ViewBag.gigId = gigId;
            return View();
        }

        [HttpPost, ActionName("PlaceOrder")]
        public ActionResult PlaceOrderPost(string bankName, int gigId, string account)
        {

            DateTime deadline = Convert.ToDateTime(Session["deadline"]);
            Response.Write(Session["requirement"]);
            var x = _OrderService.Insert(deadline, gigId, Session["userName"].ToString(), bankName, account);
            Response.Write(x);
            //ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", string.Format("alert('{1}', '{0}');", Message, Title), true);
            //Response.Write(@"<script language='javascript'>alert('The following errors have occurred: \n .');</script>");
            return RedirectToAction("Home");
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
                    var language = r.UserLanguage(user);
                    foreach (var item in language)
                    {
                        _languageService.Insert(new Language { UserName = user.UserName, LanguageInfo = item });
                    }
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