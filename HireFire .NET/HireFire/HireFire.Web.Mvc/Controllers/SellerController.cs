using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HireFire.Core.Entity;
using System.Collections;
using Hirefire.Core.Services.Interfaces;
using HireFire.Web.Mvc.Models;

namespace HireFire.Controllers
{
    public class SellerController : Controller
    {
        ISellerService _sellerService;
        IGigService _gigService;
        ISellerHeaderService _sellerHeaderService;
        ITransactionService _transactionService;
        ISkillService _skillService;
        IOrderService _orderService;
        ISellerGraphService _sellerGraphService;
        ILanguageService _languageService;

        public SellerController(ISkillService _skillService,ILanguageService _languageService,ISellerGraphService _sellerGraphService, ISellerService sellerService, IGigService gigService, ITransactionService transactionService, IOrderService orderService)
        {
            _sellerService = sellerService;
            _gigService = gigService;
            _transactionService = transactionService;
            _orderService = orderService;
            this._sellerGraphService = _sellerGraphService;
            this._languageService = _languageService;
            this._skillService = _skillService;
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


            var x = _languageService.GetByUserName("tanim");
            ViewBag.Language = x;
            var y= _skillService.GetByUserName("tanim");
            ViewBag.Skill = y;
            var user = _sellerService.GetByUserName("tanim");
            ViewBag.User = user;
            var transaction = _transactionService.GetLastTransactionBySellerUserName("tanim");
            ViewBag.Transaction = transaction;
            var allGig = _gigService.GetAllByUserName("tanim");
            ViewBag.AllGig = allGig;
            //allGig.ElementAt(0).ImagePath
            return View();
        }
        //[HttpPost]
        public ActionResult AddLanguage(string newLanguage)
        {
            string userName = "tanim";
            var y = _languageService.Insert(new Language { UserName = userName, LanguageInfo = newLanguage });
            //string userName = Session["userName"].ToString();
            //var x = _languageService.GetByUserName(userName);
            //ViewBag.Language = x;
            return (RedirectToAction("Profile"));
        }
        public ActionResult AddSkill(string newSkill)
        {
            var x=_skillService.Insert(new Skill { UserName = "tanim", SkillInfo = newSkill });
            //Response.Write(x);
            return (RedirectToAction("Profile"));
        }
        public ActionResult EditDescription(string EditedDescription)
        {
            var x = _sellerService.UpdateDescriptionByUserName("tanim", EditedDescription);
            return (RedirectToAction("Profile"));
        }

        public ActionResult Dashboard()
        {
            var gigcount = _gigService.CountByUserName("Robi");
            ViewBag.gigcount = gigcount;

            var seller = _sellerService.GetByUserName("Robi");
            ViewBag.workingHour = seller.WorkingHour;
            ViewBag.reputationPoint = seller.ReputationPoint;

            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;

            var level = seller.Level;

            if (level == 1)
            {
                ViewBag.level = "Silver";
            }
            else if (level < 4)
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
            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;
            return View();
        }
        public ActionResult PendingWork()
        {
            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;
            return View();
        }
        public ActionResult CompletedWork()
        {
            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;
            return View();
        }
        public ActionResult AllGigs()
        {
            var gigs = _gigService.GetAllByUserName("Robi");

            List<Gig> gig = new List<Gig>();
            List<int> numberOfOrder = new List<int>();
            List<float> avgRating = new List<float>();

            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;

            foreach (var g in gigs)
            {
                gig.Add(g);
                var order = _orderService.GetByGigId(g.Id);
                int count = 0;
                float rating = 0;
                foreach (var o in order)
                {
                    rating += o.Rating;
                    count++;
                }
                if (float.IsNaN(rating))
                {
                    avgRating.Add(0f);
                }
                else
                {
                    avgRating.Add(rating / count);
                }

                numberOfOrder.Add(count);
            }

            ViewBag.gigs = gig;
            ViewBag.numberOfOrder = numberOfOrder;
            ViewBag.avgRating = avgRating;
            return View();
        }

        public ActionResult TopGigs()
        {
            var gigs = _gigService.GetAllByUserName("Robi");

            List<Gig> gig = new List<Gig>();
            List<int> numberOfOrder = new List<int>();

            List<float> avgRating = new List<float>();

            foreach (var g in gigs)
            {
                gig.Add(g);
                var order = _orderService.GetByGigId(g.Id);
                int count = 0;
                float rating = 0;
                foreach (var o in order)
                {
                    rating += o.Rating;
                    count++;
                }
                numberOfOrder.Add(count);
                avgRating.Add(rating / count);
            }

            List<int> numOfOrder = new List<int>();
            numOfOrder = numberOfOrder.Take(5).ToList();

            int largesub;

            for (int i = 0; i < 5; i++)
            {
                largesub = i;
                for (int j = i + 1; j < 5; j++)
                {
                    if (numOfOrder[j] > numOfOrder[largesub])
                    {
                        largesub = j;
                    }
                }
                int temp1 = numOfOrder[i];
                numOfOrder[i] = numOfOrder[largesub];
                numOfOrder[largesub] = temp1;

                Gig temp2 = gig[i];
                gig[i] = gig[largesub];
                gig[largesub] = temp2;

                float temp3 = avgRating[i];
                avgRating[i] = avgRating[largesub];
                avgRating[largesub] = temp3;

            }

            numOfOrder = numOfOrder.Where(i => i >= 1).ToList();
            ViewBag.gigs = gig;
            ViewBag.numberOfOrder = numOfOrder;
            ViewBag.avgRating = avgRating;
            return View();
        }

        public ActionResult TopBuyer()
        {
            var transaction = _transactionService.GetBySellerUserName("Robi").Distinct();

            foreach (var t in transaction)
            {
                var order = _orderService.GetById(t.OrderId);
            }
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
            var t = _transactionService.GetBySellerUserName("Robi");
            ViewBag.transaction = t;

            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;
            return View();
        }
        public ActionResult BalanceReport()
        {


            //var totalIncome =  _transactionService.TotalIncome("Robi");
            //ViewBag.totalIncome = totalIncome;
            //var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            //ViewBag.balance = balance;
            //ViewBag.lastMonthIncome = _transactionService.LastMonthIncome("Robi");
            //return View();


            var totalIncome =  _transactionService.TotalIncome("Robi");
            ViewBag.totalIncome = totalIncome;
            var balance = _transactionService.GetBalanceBySellerUserName("Robi");
            ViewBag.balance = balance;
            ViewBag.lastMonthIncome = _transactionService.LastMonthIncome("Robi");

            var lastYearIncomeGraph = _sellerGraphService. LastYearIncomeGraphByUserName("Robi");
            ViewBag.lastYearIncomeGraph = lastYearIncomeGraph;
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
        public ActionResult CreateGig()
        {
            return View();
        }
        [HttpPost,ActionName("CreateGig")]
        public ActionResult CreateGig(string category, string gigTitle, int gigPrice, string gigDescription, HttpPostedFileBase gigImage)
        {
            //Response.Write(category+"  "+gigTitle+"  "+gigPrice+"  "+gigDescription);
            var file = gigImage;
            string picName="";
            if (file != null)
            {
                picName = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Contents/Image/Gig"), picName);
                // file is uploaded
                file.SaveAs(path);

                //Response.Write(pic);
            }
            ReturnCategoryId cd=new ReturnCategoryId();
            int categoryId=cd.ReturnCategoryIdByCategoryName(category);
            var x=_gigService.Insert(new Gig { SellerUserName = "tanim", CategoryId = categoryId, Description = gigDescription, ImagePath = picName, Date = DateTime.Now, Price = gigPrice, Title = gigTitle });
            return(RedirectToAction("Profile"));
        }
        public ActionResult EditGig()
        {
            return View();
        }
        public ActionResult AccountStatement()
        {
            return View();
        }

        public void Withdraw(string withdrawAmount)
        {

            _transactionService.Insert(new Transaction { SellerName = "Robi", BuyerPaid = 0, SellerEarned = 0, WithdrawAmount = Convert.ToInt32(withdrawAmount), OrderId = 0, PromotionId = 0, HireFireProfit = 0, Date = DateTime.Now });
            //return RedirectToAction("Account");
        }

        public ActionResult AllGigsForFrame()
        {
            var gigs = _gigService.GetAllByUserName("Robi");

            List<Gig> gig = new List<Gig>();
            List<int> numberOfOrder = new List<int>();
            List<float> avgRating = new List<float>();


            foreach (var g in gigs)
            {
                gig.Add(g);
                var order = _orderService.GetByGigId(g.Id);
                int count = 0;
                float rating = 0;
                foreach (var o in order)
                {
                    rating += o.Rating;
                    count++;
                }
                if (float.IsNaN(rating))
                {
                    avgRating.Add(0f);
                }
                else
                {
                    avgRating.Add(rating / count);
                }

                numberOfOrder.Add(count);
            }

            ViewBag.gigs = gig;
            ViewBag.numberOfOrder = numberOfOrder;
            ViewBag.avgRating = avgRating;
            return View();
        }

    }
}


