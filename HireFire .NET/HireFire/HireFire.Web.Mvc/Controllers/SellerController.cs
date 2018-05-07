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
        ISellerTableService _sellerTableService;
        ITaskService _taskService;
        IBuyerService _buyerService;
        public SellerController(ISellerTableService _sellerTableService,ISkillService _skillService,ILanguageService _languageService,ISellerGraphService _sellerGraphService, ISellerService sellerService, IGigService gigService, ITransactionService transactionService, IOrderService orderService, ITaskService taskService,IBuyerService buyerService)
        {
            _sellerService = sellerService;
            _gigService = gigService;
            _transactionService = transactionService;
            _orderService = orderService;
            this._sellerGraphService = _sellerGraphService;
            this._languageService = _languageService;
            this._skillService = _skillService;
            this._sellerTableService = _sellerTableService;
            _taskService = taskService;

            _buyerService = buyerService;
        }


        //public bool Insert()
        //{
        //    var x = false;

        //        x = _service.Insert(new Seller { UserName = Session["UserName"].ToString(),Name = "Ibrahim", JoiningDate = DateTime.Now, Description="sdf",
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
            if (Session["userName"] == null)
            {
                return RedirectToAction("SignIN", "Others");
            }

            var x = _languageService.GetByUserName(Session["UserName"].ToString());
            ViewBag.Language = x;
            var y = _skillService.GetByUserName(Session["UserName"].ToString());
            ViewBag.Skill = y;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            var transaction = _transactionService.GetLastTransactionBySellerUserName(Session["UserName"].ToString());
            ViewBag.Transaction = transaction;
            var allGig = _gigService.GetAllByUserName(Session["UserName"].ToString());
            ViewBag.AllGig = allGig;
            //allGig.ElementAt(0).ImagePath
            return View();
        }
        //[HttpPost]
        public ActionResult AddLanguage(string newLanguage)
        {
            string userName = Session["UserName"].ToString();
            var y = _languageService.Insert(new Language { UserName = userName, LanguageInfo = newLanguage });
            //string userName = Session["userName"].ToString();
            //var x = _languageService.GetByUserName(userName);
            //ViewBag.Language = x;
            return (RedirectToAction("Profile"));
        }
        public ActionResult AddSkill(string newSkill)
        {
            var x=_skillService.Insert(new Skill { UserName = Session["UserName"].ToString(), SkillInfo = newSkill });
            //Response.Write(x);
            return (RedirectToAction("Profile"));
        }
        public ActionResult EditDescription(string EditedDescription)
        {
            var x = _sellerService.UpdateDescriptionByUserName(Session["UserName"].ToString(), EditedDescription);
            return (RedirectToAction("Profile"));
        }

        public ActionResult Dashboard()
        {
            var gigcount = _gigService.CountByUserName(Session["UserName"].ToString());
            ViewBag.gigcount = gigcount;

            var seller = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.workingHour = seller.WorkingHour;
            ViewBag.reputationPoint = seller.ReputationPoint;
            ViewBag.User = seller;

            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
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

            ViewBag.lastMonthIncome = _transactionService.LastMonthIncome(Session["UserName"].ToString());

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
            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            var Order = _sellerTableService.GetActiveWorkByUserName(Session["UserName"].ToString());//buyer name, deadline
            var AllGig = _sellerTableService.GetAllGigInformationByOrderId(Order);//gig name, gig price
            ViewBag.Order = Order;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            ViewBag.AllGig = AllGig;
            return View();
        }
        public ActionResult PendingWork()
        {
            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            var Order = _sellerTableService.GetPendingWorkByUserName(Session["UserName"].ToString());//buyer name, deadline
            var AllGig = _sellerTableService.GetAllGigInformationByOrderId(Order);//gig name, gig price
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            return View();
        }
        
        public ActionResult PendingWorkRejectedByOrderId(int orderId)
        {
            var x = _orderService.Delete(orderId);
            return RedirectToAction("PendingWork");
        }
        public ActionResult PendingWorkAcceptedByOrderId(int orderId)
        {
            var x = _orderService.UpdateWorkToActiveByOderId(orderId);
            return RedirectToAction("PendingWork");
        }
        public ActionResult CompletedWork()
        {
            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            var Order = _sellerTableService.GetCompletedWorkByUserName(Session["UserName"].ToString());//buyer name
            //Order.ElementAt(0).BuyerName
            var AllGig = _sellerTableService.GetAllGigInformationByOrderId(Order);//gig name, gig price
            var completionDate = _sellerTableService.GetTransactionForCompletionDate(Order);//CompletionDate
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.CompletionDate = completionDate;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;

            return View();
        }
        public ActionResult AllGigs()
        {
            var gigs = _gigService.GetAllByUserName(Session["UserName"].ToString());

            List<Gig> gig = new List<Gig>();
            List<int> numberOfOrder = new List<int>();
            List<float> avgRating = new List<float>();

            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;

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
            var gigs = _gigService.GetAllByUserName(Session["UserName"].ToString());

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
            var transaction = _transactionService.GetBySellerUserName(Session["UserName"].ToString()).Distinct();
            List<Buyer> buyer = new List<Buyer>();

            foreach(var t in transaction)
            {
                var b = _buyerService.GetByUserName(t.BuyerName);

                buyer.Add(b); 
            }

            ViewBag.buyer = buyer;
            ViewBag.transaction = transaction;
        
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
        public ActionResult SellerOrderProgress(int orderId)
        {
            // bool t = _taskService.Insert(new Task { OrderId = 32, TaskName = "fdfds", Status = 2, Deadline = DateTime.Now, Approbation = false, FileName = "cds" });
            IEnumerable<Task> task = _taskService.GetAllByOrderId(orderId);
            ViewBag.task = task;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            //Response.Write(task.ToList()[1].Deadline.ToString("MM/dd/yyyy"));
            ViewBag.count = task.Count();
           

            float completeCount = 0, onGoingCount = 0;
            foreach (var t in task)
            {
                if (t.Status == 3) ////3-->Complete
                {
                    completeCount++;
                }
                else if (t.Status == 2)  ////2-->On going
                {
                    onGoingCount++;
                }
            }

            int progress = (int)Math.Ceiling(((completeCount + onGoingCount / 2) / 4) * 100);

            ViewBag.progress = progress;

            Order order = _orderService.GetById(orderId);
            ViewBag.finalDeadline = order.Deadline;
            ViewBag.feedback = order.Feedback;
            ViewBag.rating = order.Rating;
            ViewBag.orderId = orderId;
            ViewBag.status = order.Status;
            ViewBag.title = _gigService.GetByGigId(order.GigId).Title;
            // Response.Write(ViewBag.title);

            return View();
        }

        [HttpPost, ActionName("BuyerOrderProgress")]
        public void BuyerOrderProgressPost(int taskId, string taskName, DateTime deadline, string identifier, int orderId)
        {
            if (identifier == "update")
            {
                _taskService.Update(new Task { TaskName = taskName, Id = taskId, Deadline = deadline});
            }


        }

        [HttpPost]
        public ActionResult Upload(int orderId, int taskId, HttpPostedFileBase uploadFile)
        {
            var file = uploadFile;
   
            if (file != null)
            {
                //Response.Write("success");
                if(taskId==0)
                {
                    string picName = "OrderId" + orderId.ToString()+ ".jpg";
                    string path = System.IO.Path.Combine(Server.MapPath("~/Contents/Image/Task/Final/"), picName);
                    // file is uploaded
                    file.SaveAs(path);
                    bool x = _orderService.UpdateFileName(new Order { FileName = picName, Id = orderId });

                    //Response.Write(picName);
                }
                else
                {
                    string picName = "OrderId" + orderId.ToString() + "_TaskId" + taskId.ToString() + ".jpg";
                    string path = System.IO.Path.Combine(Server.MapPath("~/Contents/Image/Task/Partial/"), picName);
                    // file is uploaded
                    file.SaveAs(path);
                    bool x = _taskService.UpdateFileName(new Task { FileName = picName, Id = taskId });
                    
                    //Response.Write(x);
                }
    
            }
            return RedirectToAction("SellerOrderProgress", new { orderId = orderId });
        }

        public ActionResult Account()
        {
            var t = _transactionService.GetBySellerUserName(Session["UserName"].ToString());
            ViewBag.transaction = t;

            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            return View();
        }
        public ActionResult BalanceReport()
        {


            //var totalIncome =  _transactionService.TotalIncome(Session["UserName"].ToString());
            //ViewBag.totalIncome = totalIncome;
            //var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            //ViewBag.balance = balance;
            //ViewBag.lastMonthIncome = _transactionService.LastMonthIncome(Session["UserName"].ToString());
            //return View();


            var totalIncome =  _transactionService.TotalIncome(Session["UserName"].ToString());
            ViewBag.totalIncome = totalIncome;
            var balance = _transactionService.GetBalanceBySellerUserName(Session["UserName"].ToString());
            ViewBag.balance = balance;
            ViewBag.lastMonthIncome = _transactionService.LastMonthIncome(Session["UserName"].ToString());

            var lastYearIncomeGraph = _sellerGraphService. LastYearIncomeGraphByUserName(Session["UserName"].ToString());
            ViewBag.lastYearIncomeGraph = lastYearIncomeGraph;
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
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
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
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
            var x=_gigService.Insert(new Gig { SellerUserName = Session["UserName"].ToString(), CategoryId = categoryId, Description = gigDescription, ImagePath = picName, Date = DateTime.Now, Price = gigPrice, Title = gigTitle });
            return(RedirectToAction("Profile"));
        }
        public ActionResult EditGig(int GigId)
        {
            var user = _sellerService.GetByUserName(Session["UserName"].ToString());
            ViewBag.User = user;
            var x=_gigService.GetByGigId(GigId);
            ViewBag.Gig=x;
            return View(x);
        }
        public ActionResult AccountStatement()
        {
            return View();
        }

        public void Withdraw(string withdrawAmount)
        {

            _transactionService.Insert(new Transaction { SellerName = Session["UserName"].ToString(), BuyerPaid = 0, SellerEarned = 0, WithdrawAmount = Convert.ToInt32(withdrawAmount), OrderId = 0, PromotionId = 0, HireFireProfit = 0, Date = DateTime.Now });
            //return RedirectToAction("Account");
        }

        public ActionResult AllGigsForFrame()
        {
            var gigs = _gigService.GetAllByUserName(Session["UserName"].ToString());

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


