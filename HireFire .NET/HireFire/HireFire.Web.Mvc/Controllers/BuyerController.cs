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

namespace HireFire.Controllers
{
    public class BuyerController : Controller
    {
        //
        // GET: /Buyer/

        HireFireDbContext ctx = new HireFireDbContext();
        IBuyerService _service;

        public BuyerController()
        {
            _service = new BuyerService(ctx);
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

            Category cetagory = new Category();
            cetagory.Name = "sfs";
            cetagory.Id = 1;
            //ctx.Categorys.Add(cetagory);
            //ctx.SaveChanges();
            return View();


        }
        public void Account()
        {
            var x = _service.GetByUserName("1");
            
            Response.Write(x.UserName+""+x.JoiningDate);
            

        }
        public ActionResult ActiveWork()
        {
            return View();
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
            return View();
        }



    }
}
