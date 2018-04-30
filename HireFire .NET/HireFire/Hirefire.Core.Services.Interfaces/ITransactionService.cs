using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetAll();
        //IEnumerable<Transaction> GetById(int Id);
        bool Insert(Transaction transaction);
        //bool Update(Transaction transaction);
        //bool Delete(int Id);

        
        //public IEnumerable<Transaction> GetAll()
        IEnumerable<Transaction> GetByBuyerUserName(string buyerUserName); 

        IEnumerable<Transaction> GetBySellerUserName(string sellerUserName);

        int TotalSpend(string buyerUserName);

        int LastMonthSpend(string buyerUserName);

        int TotalIncome(string sellerUserName);

        int LastMonthIncome(string sellerUserName);



        
    }
}
