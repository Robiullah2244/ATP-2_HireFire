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
    public class BuyerGraphService : IBuyerGraphService
    {
        DbContext _context;

        public BuyerGraphService(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<int> LastYearSpendGraphByUserName(string userName)
        {
            var x = _context.Set<Transaction>().Where(b => b.BuyerName == userName && b.Date.Year == DateTime.Now.Year - 1);
            var ListOfMonth = x.Select(b => b.Date.Month).Distinct();
            //var count = ListOfMonth.Count();
            int Jan = 0, Feb = 0, Mar = 0, Apr = 0, May = 0, Jun = 0, July = 0, Aug = 0, Sep = 0, Oct = 0, Nov = 0, Dec = 0;

            foreach (var item in ListOfMonth)
            {
                if (item == 1)
                {
                    var z = x.Where(b => b.Date.Month == 1).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Jan = Jan + item1;
                    }
                }
                else if (item == 2)
                {
                    var z = x.Where(b => b.Date.Month == 2).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Feb = Feb + item1;
                    }
                }
                else if (item == 3)
                {
                    var z = x.Where(b => b.Date.Month == 3).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Mar = Mar + item1;
                    }
                }
                else if (item == 4)
                {
                    var z = x.Where(b => b.Date.Month == 4).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Apr = Apr + item1;
                    }
                }
                else if (item == 5)
                {
                    var z = x.Where(b => b.Date.Month == 5).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        May = May + item1;
                    }
                }
                else if (item == 6)
                {
                    var z = x.Where(b => b.Date.Month == 6).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Jun = Jun + item1;
                    }
                }
                else if (item == 7)
                {
                    var z = x.Where(b => b.Date.Month == 7).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        July = July + item1;
                    }
                }
                else if (item == 8)
                {
                    var z = x.Where(b => b.Date.Month == 8).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Aug = Aug + item1;
                    }
                }
                else if (item == 9)
                {
                    var z = x.Where(b => b.Date.Month == 9).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Sep = Sep + item1;
                    }
                }
                else if (item == 10)
                {
                    var z = x.Where(b => b.Date.Month == 10).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Oct = Oct + item1;
                    }
                }
                else if (item == 11)
                {
                    var z = x.Where(b => b.Date.Month == 11).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Nov = Nov + item1;
                    }
                }
                if (item == 12)
                {
                    var z = x.Where(b => b.Date.Month == 12).Select(b => b.BuyerPaid);
                    foreach (var item1 in z)
                    {
                        Dec = Dec + item1;
                    }
                }

            }
            List<int> month = new List<int>();
            month.Add(Jan);
            month.Add(Feb);
            month.Add(Mar);
            month.Add(Apr);
            month.Add(May);
            month.Add(Jun);
            month.Add(July);
            month.Add(Aug);
            month.Add(Sep);
            month.Add(Oct);
            month.Add(Nov);
            month.Add(Dec);
            return month;

        }

    }
}
