using Hirefire.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireFire.Web.Mvc.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AddAdmin()
        {
            return View();
        }
        public ActionResult AdminAccountReport()
        {
            return View();
        }
        public ActionResult AdminBuyerReport()
        {
            return View();
        }
        public ActionResult AdminGigsReport()
        {
            return View();
        }
        public ActionResult AdminSellerReport()
        {
            return View();
        }
        public ActionResult AdminLastMonthIncome()
        {
            return View();
        }
        public ActionResult AdminLastMonthIncomeGraphView()
        {
            return View();
        }
        public ActionResult AdminSetting()
        {
            return View();
        }
        public ActionResult AdminTotalIncome()
        {
            return View();
        }
        public ActionResult AdminTotalUserListGraph()
        {
            return View();
        }
    }
}