﻿using HireFire.Infrastructure;
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
        ISellerService _sellerService;
        IGigService _gigService;
        ISellerHeaderService _sellerHeaderService;
        ITransactionService _transactionService;


        public SellerController(ISellerService sellerService, IGigService gigService, ITransactionService transactionService)
        {
            _sellerService = sellerService;
            _gigService = gigService;
            _transactionService = transactionService;

        }


        //public bool Insert()
        //{
        //    var x = false;
         
        //        x = _service.Insert(new Seller { UserName = "Tanim",Name = "Ibrahim", JoiningDate = DateTime.Now, Description="sdf",
        //        Level=1,ReputationPoint=12,WorkingHour="2 hour", Email = "sdsfc", ImagePath = "scsd", LastActiveTimeInfo = DateTime.Now,
        //        BankName="Banani",AccountNumber="ABC",District="Com",Address="sd",PostalCode=12,MobileNumber="sad",
        //        InstituteAttendFrom=DateTime.Now,InstituteName="AIUB",Degree="SD",Area="Abc",InstituteAttendTo=DateTime.Now});
            
        //    return x;
        //}

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
            var gigcount = _gigService.CountByUserName("Robi");
            ViewBag.gigcount = gigcount;

            var seller = _sellerService.GetByUserName("Robi");
            ViewBag.workingHour = seller.WorkingHour;
            ViewBag.reputationPoint = seller.ReputationPoint;
            var level = seller.Level;

            if(level==1)
            {
                ViewBag.level = "Silver";
            }
            else if(level<4)
            {
                ViewBag.level = "Gold";
            }
            else
            {
                ViewBag.level = "Platinum";
            }

            ViewBag.lastMonthIncome = _transactionService.LastMonthIncome("Robi");

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

        public ActionResult Statistics()
        {
            return View();
        }
        public ActionResult Setting()
        {
            return View();
        }
        public ActionResult GigInventory()
        {
            return View();
        }
        public ActionResult AccountStatement()
        {
            return View();
        }
    }
}


