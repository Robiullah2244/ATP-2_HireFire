using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Services
{
    public class OrderService : IOrderService
    {
        DbContext _context;
        public OrderService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>();
        }

        public Order GetById(int id)
        {
            return _context.Set<Order>().Where(o => o.Id == id).SingleOrDefault();
        }

        public Order MostPopularGig()
        {
            throw new NotImplementedException();
        }

        public bool Insert(DateTime deadline, int gigId, string userName, string bankName,string account,string sellerName)
        {
            Order order = new Order();
            order.GigId = gigId;
            order.Date = DateTime.Now;
            order.Deadline = deadline;
            order.BuyerName = userName;
            order.BankName = bankName;
            order.AccountNumber = account;
            order.Status = 1;
            order.Feedback = "";
            order.Rating = 0;
            order.SellerName = sellerName;

            //order.GigId = 1;
            //order.Date = DateTime.Now;
            //order.Deadline = DateTime.Now;
            //order.BuyerName = "dfds";
            //order.BankName = "dsdsdf";
            //order.AccountNumber = "sdsf";
            //order.Status = 0;
            //order.Feedback = "s";
            //order.Rating = 0;
            try
            {
                _context.Set<Order>().Add(order);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool Update(Order order)
        {
            try
            {
                var targetOrder = _context.Set<Order>().Where(o => o.Id == order.Id).FirstOrDefault();
                targetOrder.Deadline = order.Deadline;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateStatus(Order order)
        {
            try
            {
                var targetOrder = _context.Set<Order>().Where(o => o.Id == order.Id).FirstOrDefault();
                targetOrder.Status = order.Status;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateRating(Order order)
        {
            try
            {
                var targetOrder = _context.Set<Order>().Where(o => o.Id == order.Id).FirstOrDefault();
                targetOrder.Rating = order.Rating;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool UpdateFeedback(Order order)
        {
            try
            {
                var targetOrder = _context.Set<Order>().Where(o => o.Id == order.Id).FirstOrDefault();
                targetOrder.Feedback = order.Feedback;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool UpdateFileName(Order order)
        {
            try
            {
                var targetOrder = _context.Set<Order>().Where(o => o.Id == order.Id).FirstOrDefault();
                targetOrder.FileName = order.FileName;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var targetedOrder = GetById(id);
                _context.Set<Order>().Remove(targetedOrder);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Order> GetByGigId(int gigId)
        {
            return _context.Set<Order>().Where(o => o.GigId == gigId);
        }

        public int GetLatestOrderNumber()
        {
            var orderNumber = _context.Set<Order>().Select(n => n.Id).Max()+1;
            if(orderNumber==null)
            {
                return 1;
            }
            return orderNumber;

        }
        public bool UpdateWorkToActiveByOderId(int orderId)
        {
            try
            {
                var targetedOrder = GetById(orderId);
                targetedOrder.Status = 2;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
