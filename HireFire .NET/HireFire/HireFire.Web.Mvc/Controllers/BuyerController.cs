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
        public IBuyerService _service;

        public BuyerController(IBuyerService service)
        {
            _service = service;
        }

        //HireFireDbContext ctx = new HireFireDbContext();
        //IBuyerService _service;

        //public BuyerController()
        //{
        //    _service = new BuyerService(ctx);
        //}



        public bool Insert()
        {
            var x=false;
            for(int i=10;i<14;i++)
            {
                x = _service.Insert(new Buyer { UserName = "Tanim"+i, JoiningDate = DateTime.Now, Email = "sdsfc", ImagePath = "scsd", LastActiveTimeInfo = DateTime.Now, Name = "Robi" });
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

            Category cetagory = new Category();
            cetagory.Name = "sfs";
            cetagory.Id = 1;
            //ctx.Categorys.Add(cetagory);
            //ctx.SaveChanges();
            return View();


        }
        //public void Dashboard()
        //{
        //    HireFireDbContext ctx = new HireFireDbContext();
        //    //Category cetagory = new Category();
        //    //cetagory.Name = "sfs";
        //    //cetagory.Id = 1;
        //    var x = _service.GetAll().ToList();
        //    foreach (var x1 in x)
        //    {
        //        Response.Write(x1.ContactNumber);
        //        Response.Write(x1.UserName);
        //        Response.Write(x1.JoiningDate);

        //    }
        //    // return Content();


        //}
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

        //[HttpPost]
        public bool BuyerSetting()
        {
            var x = _service.Update(new Buyer { UserName="robi", Email = "sdsfc", Name = "Tanim" });
            return x;
        }
        public bool Delete()
        {
            var x = _service.Delete("robi2");
            return x;
        }

    }
}
