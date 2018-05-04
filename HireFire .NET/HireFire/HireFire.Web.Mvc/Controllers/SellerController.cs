using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireFire.Core.Entity;
using System.Collections;
using Hirefire.Core.Services.Interfaces;

namespace HireFire.Controllers
{
    public class SellerController : Controller
    {
        public ISellerService _service;

        public SellerController(ISellerService service)
        {
            _service = service;
        }
        public bool Insert()
        {
            var x = false;
         
                x = _service.Insert(new Seller { UserName = "Tanim",Name = "Ibrahim", JoiningDate = DateTime.Now, Description="sdf",
                Level=1,ReputationPoint=12,WorkingHour="2 hour", Email = "sdsfc", ImagePath = "scsd", LastActiveTimeInfo = DateTime.Now,
                BankName="Banani",AccountNumber="ABC",District="Com",Address="sd",PostalCode=12,MobileNumber="sad",
                InstituteAttendFrom=DateTime.Now,InstituteName="AIUB",Degree="SD",Area="Abc",InstituteAttendTo=DateTime.Now});
            
            return x;
        }

        // GET: Seller
        public ActionResult Profile()
        {
            // HireFireDbContext ctx = new HireFireDbContext();
            //Category cetagory = new Category();
            //cetagory.Name = "sfs";
            //cetagory.Id = 1;
            // ctx.Admins.ToList();
            return View();
        }

        public ActionResult Dashboard()
        {
            //  HireFireDbContext ctx = new HireFireDbContext();
            //Category cetagory = new Category();
            //cetagory.Name = "sfs";
            //cetagory.Id = 1;
            //  return ctx.Categorys.ToList();

            return View();
        }
        public ActionResult ProfileFromAdminView()
        {
            return View();
        }

        public ActionResult SellerList()
        {
            return View();
        }

        public ActionResult ActiveWork()
        {
            return View();
        }
        public ActionResult PendingWork()
        {
            return View();
        }
        public ActionResult CompletedWork()
        {
            return View();
        }
        public ActionResult AllGigs()
        {
            return View();
        }
        public ActionResult TopGigs()
        {
            return View();
        }
        public ActionResult TopBuyer()
        {
            return View();
        }
        public ActionResult Registration1()
        {
            return View();
        }
        public ActionResult Registration2()
        {
            return View();
        }
        public ActionResult Registration3()
        {
            return View();
        }
        public ActionResult SellerOrderProgress()
        {
            return View();
        }
        public ActionResult Account()
        {
            return View();
        }
        public ActionResult BalanceReport()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Statistics()
        {
            return View();
        }
        public ActionResult Setting()
        {
            return View();
        }
    }
}


