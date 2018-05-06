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
    public class TransactionService : ITransactionService
    {
        DbContext _context;

        public TransactionService(DbContext context)
        {
            _context = context;
        }


        public int TotalSpend(string userName)
        {
            int totalSpend = 0;
            var buyer = _context.Set<Transaction>().Where(b => b.BuyerName == userName);
            foreach (var x in buyer)
            {
                totalSpend += x.BuyerPaid;
            }
            return totalSpend;
        }

        public int LastMonthSpend(string userName)
        {
            int lastMonthSpend = 0;
            var buyer= _context.Set<Transaction>().Where(b => (b.BuyerName == userName)).ToList().Where(b=>((DateTime.Now-b.Date).Days<=30) );

            foreach (var x in buyer)
            {
                lastMonthSpend += x.BuyerPaid;
            }


            return lastMonthSpend;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Set<Transaction>().ToList();
        }




        public IEnumerable<Transaction> GetByBuyerUserName(string userName)
        {
            return _context.Set<Transaction>().Where(b => b.BuyerName == userName);
            //return _context.Set<Buyer>().ToList();
        }



        public  IEnumerable<Transaction> GetBySellerUserName(string userName)
        {
            return _context.Set<Transaction>().Where(b => b.SellerName == userName);
            //return _context.Set<Buyer>().ToList();
        }



        public bool Insert(Transaction transaction)
        {
            try
            {
                _context.Set<Transaction>().Add(transaction);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int TotalIncome(string sellerUserName)
        {
            throw new NotImplementedException();
        }

        public float LastMonthIncome(string userName)
        {
            float lastMonthIncome = 0;
            var buyer = _context.Set<Transaction>().Where(s => (s.SellerName == userName)).ToList().Where(s => ((DateTime.Now - s.Date).Days <= 30));

            foreach (var x in buyer)
            {
                lastMonthIncome += x.SellerEarned;
            }


            return lastMonthIncome;
        }


        public float GetBalanceBySellerUserName(string sellerUserName)
        {
            var transaction = _context.Set<Transaction>().Where(s => s.SellerName == sellerUserName);
            float balance = 0;
            foreach(var t in transaction)
            {
                if(t.OrderId>0)
                {
                    balance += t.SellerEarned;
                }
                else
                {
                    balance -= t.WithdrawAmount;
                }
            }

            return balance;
        }
       
    }
    

}
