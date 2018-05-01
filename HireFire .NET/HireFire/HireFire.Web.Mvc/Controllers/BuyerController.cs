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


        public BuyerController(IBuyerService service, ITransactionService transactionService)
        {
            _buyerService = service;
            _transactionService = transactionService;
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

            //Category cetagory = new Category();
            //cetagory.Name = "sfs";
            //cetagory.Id = 1;
            Admin a = new Admin();
            a.ContactNumber = "4546";
            a.JoiningDate = DateTime.Now;
            a.UserName = "6789";
            //ctx.Admins.Add(a);

            //ctx.SaveChanges();

            return View();
        }

        public ActionResult Dashboard()
        {
            _buyerService.GetByUserName("Robi");

            int totalSpend = _transactionService.TotalSpend("Robi");

            int lastMonthSpend = _transactionService.LastMonthSpend("Robi");

            var transaction = _transactionService.GetByBuyerUserName("robi");


            ViewBag.totalSpend = totalSpend;
            ViewBag.lastMonthSpend = lastMonthSpend;

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
            IEnumerable<Transaction> transaction = _transactionService.GetByBuyerUserName("Robi");
            return View(transaction);
            

        }
        public void ActiveWork()
        {
            _transactionService.GetByBuyerUserName("robi");
            DateTime d = DateTime.MinValue;
            Response.Write((DateTime.Now - d).Days);
            //return View();
        }
        public ActionResult CompletedWork()
        {
            return View();
        }
        public ActionResult PendingWork()
        {
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
