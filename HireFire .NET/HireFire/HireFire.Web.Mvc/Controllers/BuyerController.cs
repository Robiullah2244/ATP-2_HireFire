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
        IOrderService _orderService;
        ITaskService _taskService;
        IGigService _gigService;

        public BuyerController(IOrderService _orderService, IBuyerTableService _buyerTableService, IBuyerService service, ITransactionService transactionService, ILanguageService _languageService, IBuyerGraphService _buyerGraphService, ITaskService taskService, IGigService gigService)
        {
            _buyerService = service;
            _transactionService = transactionService;
            this._languageService = _languageService;
            this._buyerGraphService = _buyerGraphService;
            this._buyerTableService = _buyerTableService;
            this._orderService = _orderService;
            _taskService = taskService;
            _gigService = gigService;
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
                var user = _buyerService.GetByUserName(userName);
                ViewBag.User = user;
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
            var user = _buyerService.GetByUserName(Session["userName"].ToString());
            ViewBag.User = user;
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
            if (AccountTransaction != null)
            {
            //foreach (var item in x)
            //{
            //    Response.Write(item.SellerName + "  " + item.BuyerPaid + "<br/>");
            //}
                var GigName = _buyerTableService.GetAllGigName(AccountTransaction);
                var sellerName = _buyerTableService.GetAllSellerNameList(AccountTransaction);
                ViewBag.AccountTransaction = AccountTransaction;
                ViewBag.GigName = GigName;
                ViewBag.SellerName = sellerName;
                var user = _buyerService.GetByUserName(Session["userName"].ToString());
                ViewBag.User = user;
            }
            return View();
            //foreach (var item in y)
            //{
            //    Response.Write(item + "<br/>");
            //}
            //IEnumerable<Transaction> transaction = _transactionService.GetByBuyerUserName("Robi");
            //return View(transaction);
        }
        
        public ActionResult CompletedWork()
        {
            var Order = _buyerTableService.GetCompletedWorkByUserName(Session["userName"].ToString());
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            var completionDate = _buyerTableService.GetTransactionForCompletionDate(Order);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            ViewBag.CompletionDate = completionDate;
            var user = _buyerService.GetByUserName(Session["userName"].ToString());
            ViewBag.User = user;
            //var x=Order.ElementAt(0).Date;
            return View();
        }
        public ActionResult PendingWork()
        {
            var Order = _buyerTableService.GetPendingWorkByUserName(Session["userName"].ToString());
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            var user = _buyerService.GetByUserName(Session["userName"].ToString());
            ViewBag.User = user;
            return View();
        }
        public ActionResult ActiveWork()
        {
            var Order = _buyerTableService.GetActiveWorkByUserName(Session["userName"].ToString());
            var AllGig = _buyerTableService.GetAllGigInformationByOrderId(Order);
            var sellerName = _buyerTableService.GetAllSellerNameListByGig(AllGig);
            ViewBag.Order = Order;
            ViewBag.AllGig = AllGig;
            ViewBag.SellerName = sellerName;
            var user = _buyerService.GetByUserName(Session["userName"].ToString());
            ViewBag.User = user;
            return View();
            //_transactionService.GetByBuyerUserName(Session["userName"].ToString());
            //DateTime d = DateTime.MinValue;
            //Response.Write((DateTime.Now - d).Days);
            //return View();

        }
        //[HttpPost, ActionName("PendingWork")]
        public ActionResult PendingWorkDeleteByOrderId(int orderId)
        {
            var x = _orderService.Delete(orderId);
            return RedirectToAction("PendingWork");
            //Response.Write(orderId);
        }
        public ActionResult BuyerList()
        {
            return View();
        }
        public ActionResult BuyerOrderProgress(int orderId)
        {
           // bool t = _taskService.Insert(new Task { OrderId = 32, TaskName = "fdfds", Status = 2, Deadline = DateTime.Now, Approbation = false, FileName = "cds" });
            IEnumerable<Task> task = _taskService.GetAllByOrderId(orderId);
            ViewBag.task = task;
            //Response.Write(task.ToList()[1].Deadline.ToString("MM/dd/yyyy"));
            ViewBag.count = task.Count();

            float completeCount=0, onGoingCount=0;
            foreach(var t in task)
            {
                if(t.Status==3) ////3-->Complete
                {
                    completeCount++;
                }
                else if(t.Status==2)  ////2-->On going
                {
                    onGoingCount++;
                }
            }

            int progress = (int)Math.Ceiling(((completeCount + onGoingCount / 2) / 4) * 100);
            var user = _buyerService.GetByUserName(Session["userName"].ToString());
            ViewBag.User = user;
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
        public void BuyerOrderProgressPost(int taskId, string taskName, DateTime deadline, string identifier, int orderId, bool approve)
        {
            if(identifier=="update")
            {
                _taskService.Update(new Task { TaskName = taskName, Id = taskId, Deadline = deadline, Approbation=approve});
            }

            else if (identifier == "insert")
            {
                _taskService.Insert(new Task { TaskName = taskName, Deadline = deadline, OrderId = orderId });
            }

            else if (identifier == "Final Task Deadline")
            {
                _orderService.Update(new Order { Deadline = deadline, Id=orderId });
            }
     
            
        }

        public ActionResult BuyerSetting()
        {
            var x = _buyerService.GetByUserName(Session["userName"].ToString());
            if(x!=null)
            {
                ViewBag.Name = x.Name;
                ViewBag.Email = x.Email;
                var user = _buyerService.GetByUserName(Session["userName"].ToString());
                ViewBag.User = user;
            }
            return View();
        }

        [HttpPost,ActionName("BuyerSetting")]
        public bool BuyerSettingPost()
        {
            var x = _buyerService.UpdateProfileByUserName( Session["userName"].ToString(), "Tanim", "Tanim" );
            return x;
        }
        public bool Delete()
        {
            var x = _buyerService.Delete("robi2");
            return x;
        }

        public void TaskApprove(int orderId)
        {
            _orderService.UpdateStatus(new Order { Status = 3, Id=orderId });
        }

        public void Feedback(int orderId, int star, string identifier, string feedback)
        {
            if(identifier=="Star")
            {
                 _orderService.UpdateRating(new Order { Rating = star, Id = orderId });
            }
            if(identifier=="Feedback")
            {
                _orderService.UpdateFeedback(new Order { Feedback = feedback, Id = orderId });
            }
           
        }

        public FileResult Download(int orderId , int taskId)
        {
            if(taskId==0)
            {
                string fileName = _orderService.GetById(orderId).FileName;
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\xampp\htdocs\ProjectAtp-2\ATP-2_HireFire\ATP-2_HireFire\HireFire .NET\HireFire\HireFire.Web.Mvc\Contents\Image\Task\Final\" + fileName);
                // string fileName1 = "Order"+orderId.ToString()+"_Task"+taskId.ToString();
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            else
            {
                string fileName = _taskService.GetById(taskId).FileName;
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"C:\xampp\htdocs\ProjectAtp-2\ATP-2_HireFire\ATP-2_HireFire\HireFire .NET\HireFire\HireFire.Web.Mvc\Contents\Image\Task\Partial\" + fileName);
                // string fileName1 = "Order"+orderId.ToString()+"_Task"+taskId.ToString();
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }

        }

    }
}
