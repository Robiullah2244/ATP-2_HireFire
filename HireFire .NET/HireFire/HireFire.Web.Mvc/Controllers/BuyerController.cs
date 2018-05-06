using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireFire.Core.Entity;
using System.Collections;
using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Services;

namespace HireFire.Web.Mvc.Controllers
{
    public class BuyerController : Controller
    {
        //
        // GET: /Buyer/
        IBuyerService _buyerService;
        ITransactionService _transactionService;
        ILanguageService _languageService;
        IBuyerGraphService _buyerGraphService;
        IBuyerTableService _buyerTableService;

        public BuyerController(IBuyerTableService _buyerTableService,IBuyerService service, ITransactionService transactionService, ILanguageService _languageService, IBuyerGraphService _buyerGraphService)
        {
            _buyerService = service;
            _transactionService = transactionService;
            this._languageService = _languageService;
            this._buyerGraphService = _buyerGraphService;
            this._buyerTableService = _buyerTableService;
        }

        //HireFireDbContext ctx = new HireFireDbContext();
        //IBuyerService _buyerService;

        //public BuyerController()
        //{
        //    _buyerService = new BuyerService(ctx);
        //}



        public bool Insert()
        {
            var x=false;
            for(int i=10;i<14;i++)
            {
                x = _buyerService.Insert(new Buyer { UserName = "Tanim"+i, JoiningDate = DateTime.Now, Email = "sdsfc", ImagePath = "scsd", LastActiveTimeInfo = DateTime.Now, Name = "Robi" });
            }
            return x;
        }

        public ActionResult Profile()
        {
            ////Category cetagory = new Category();
            ////cetagory.Name = "sfs";
            ////cetagory.Id = 1;
            //Admin a = new Admin();
            //a.ContactNumber = "4546";
            //a.JoiningDate = DateTime.Now;
            //a.UserName = "6789";
            ////ctx.Admins.Add(a);

            ////ctx.SaveChanges();
            //return View();
            if (Session["userName"] != null)
            {
                //return View(_buyerService.GetByUserName(userName));
                string userName=Session["userName"].ToString();
                var x=_languageService.GetByUserName(userName);
                ViewBag.Language=x;
                return View(_buyerService.GetByUserName(userName));
            }
            else
            {
                return RedirectToAction("SignIN", "Others");
            }
        }
        [HttpPost]
        public ActionResult Profile(string newLanguage)
        {

            var y=_languageService.Insert(new Language { UserName = Session["userName"].ToString(), LanguageInfo = newLanguage });
            string userName = Session["userName"].ToString();
            var x = _languageService.GetByUserName(userName);
            ViewBag.Language = x;
            return View(_buyerService.GetByUserName(userName));
        }


        public ActionResult Dashboard(string userName="tanim")
        {
            _buyerService.GetByUserName(userName);

            int totalSpend = _transactionService.TotalSpend(userName);

            int lastMonthSpend = _transactionService.LastMonthSpend(userName);

            var transaction = _transactionService.GetByBuyerUserName(userName);
            var lastYearSpendGraph= _buyerGraphService.LastYearSpendGraphByUserName(userName);
            //var v = lastYearSpendGraph.ElementAt(0);
            ViewBag.lastYearSpendGraph = lastYearSpendGraph;

            ViewBag.totalSpend = totalSpend;
            ViewBag.lastMonthSpend = lastMonthSpend;
            ViewBag.lastMonthSpend = lastMonthSpend;
            //ViewBag.Jan=lastYearSpendGraph.ElementAt(4);

            return View();
            //Response.Write(lastMonthSpend + " " + totalSpend);

        }
        //public void Dashboard()
        //{
        //    HireFireDbContext ctx = new HireFireDbContext();
        //    //Category cetagory = new Category();
        //    //cetagory.Name = "sfs";
        //    //cetagory.Id = 1;
        //    var x = _buyerService.GetAll().ToList();
        //    foreach (var x1 in x)
        //    {
        //        Response.Write(x1.ContactNumber);
        //        Response.Write(x1.UserName);
        //        Response.Write(x1.JoiningDate);

        //    }
        //    // return Content();


        //}
        public ActionResult Account()
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("SignIN", "Others");
            }
            var AccountTransaction = _buyerTableService.GetTransaction(Session["userName"].ToString());
            //foreach (var item in x)
            //{
            //    Response.Write(item.SellerName + "  " + item.BuyerPaid + "<br/>");
            //}
            var GigName = _buyerTableService.GetAllGigName(AccountTransaction);
            var sellerName = _buyerTableService.GetAllSellerNameList(AccountTransaction);
            ViewBag.AccountTransaction = AccountTransaction;
            ViewBag.GigName = GigName;
            ViewBag.SellerName = sellerName;
            return View();
            //foreach (var item in y)
            //{
            //    Response.Write(item + "<br/>");
            //}
            //IEnumerable<Transaction> transaction = _transactionService.GetByBuyerUserName("Robi");
            //return View(transaction);
        }
        public ActionResult ActiveWork()
        {
            var Order = _buyerTableService.GetActiveWorkByUserName("tanim");
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            return View();
            //_transactionService.GetByBuyerUserName("robi");
            //DateTime d = DateTime.MinValue;
            //Response.Write((DateTime.Now - d).Days);
            //return View();

        }
        public ActionResult CompletedWork()
        {
            var Order = _buyerTableService.GetCompletedWorkByUserName("tanim");
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            var completionDate = _buyerTableService.GetTransactionForCompletionDate(Order);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            ViewBag.CompletionDate = completionDate;
            //var x=Order.ElementAt(0).Date;
            return View();
        }
        public ActionResult PendingWork()
        {
            var Order = _buyerTableService.GetPendingWorkByUserName("tanim");
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            return View();
        }
        public ActionResult BuyerList()
        {
            return View();
        }
        public ActionResult BuyerOrderProgress()
        {
            return View();
        }

        public ActionResult BuyerSetting()
        {
            var x = _buyerService.GetByUserName("robi");
            if(x!=null)
            {
                ViewBag.Name = x.Name;
                ViewBag.Email = x.Email;
            }
            return View();
        }

        [HttpPost,ActionName("BuyerSetting")]
        public bool BuyerSettingPost()
        {
            var x = _buyerService.UpdateProfileByUserName( "robi", "Tanim", "Tanim" );
            return x;
        }
        public bool Delete()
        {
            var x = _buyerService.Delete("robi2");
            return x;
        }

    }
}
