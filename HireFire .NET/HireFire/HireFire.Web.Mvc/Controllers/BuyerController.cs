using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireFire.Core.Entity;
using System.Collections;

namespace HireFire.Controllers
{
    public class BuyerController : Controller
    {
        //
        // GET: /Buyer/

        public  ActionResult Profile()
        {
            HireFireDbContext ctx = new HireFireDbContext();
            //Category cetagory = new Category();
            //cetagory.Name = "sfs";
            //cetagory.Id = 1;
            ctx.Admins.ToList();
            return View();
        }

        public IEnumerable Dashboard()
        {
            HireFireDbContext ctx = new HireFireDbContext();
            //Category cetagory = new Category();
            //cetagory.Name = "sfs";
            //cetagory.Id = 1;
            return ctx.Categorys.ToList();
            
            
        }
        public ActionResult Account()
        {
            return View();
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
