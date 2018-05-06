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
    public class SellerGraphService : ISellerGraphService
    {
        DbContext _context;

        public SellerGraphService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<double> LastYearIncomeGraphByUserName(string sellerUserName)
        {
            var x = _context.Set<Transaction>().Where(b => b.SellerName == sellerUserName && b.Date.Year == DateTime.Now.Year - 1);
            var ListOfMonth = x.Select(b => b.Date.Month).Distinct();
            //var count = ListOfMonth.Count();
            double Jan = 0, Feb = 0, Mar = 0, Apr = 0, May = 0, Jun = 0, July = 0, Aug = 0, Sep = 0, Oct = 0, Nov = 0, Dec = 0;

            foreach (var item in ListOfMonth)
            {
                if (item == 1)
                {
                    var z = x.Where(b => b.Date.Month == 1).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Jan = Jan + item1;
                    }
                }
                else if (item == 2)
                {
                    var z = x.Where(b => b.Date.Month == 2).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Feb = Feb + item1;
                    }
                }
                else if (item == 3)
                {
                    var z = x.Where(b => b.Date.Month == 3).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Mar = Mar + item1;
                    }
                }
                else if (item == 4)
                {
                    var z = x.Where(b => b.Date.Month == 4).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Apr = Apr + item1;
                    }
                }
                else if (item == 5)
                {
                    var z = x.Where(b => b.Date.Month == 5).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        May = May + item1;
                    }
                }
                else if (item == 6)
                {
                    var z = x.Where(b => b.Date.Month == 6).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Jun = Jun + item1;
                    }
                }
                else if (item == 7)
                {
                    var z = x.Where(b => b.Date.Month == 7).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        July = July + item1;
                    }
                }
                else if (item == 8)
                {
                    var z = x.Where(b => b.Date.Month == 8).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Aug = Aug + item1;
                    }
                }
                else if (item == 9)
                {
                    var z = x.Where(b => b.Date.Month == 9).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Sep = Sep + item1;
                    }
                }
                else if (item == 10)
                {
                    var z = x.Where(b => b.Date.Month == 10).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Oct = Oct + item1;
                    }
                }
                else if (item == 11)
                {
                    var z = x.Where(b => b.Date.Month == 11).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Nov = Nov + item1;
                    }
                }
                if (item == 12)
                {
                    var z = x.Where(b => b.Date.Month == 12).Select(b => b.SellerEarned);
                    foreach (var item1 in z)
                    {
                        Dec = Dec + item1;
                    }
                }

            }
            List<double> month = new List<double>();
            month.Add(Math.Round(Jan, 2));
            month.Add(Math.Round(Feb, 2));
            month.Add(Math.Round(Mar, 2));
            month.Add(Math.Round(Apr, 2));
            month.Add(Math.Round(May, 2));
            month.Add(Math.Round(Jun, 2));
            month.Add(Math.Round(July, 2));
            month.Add(Math.Round(Aug, 2));
            month.Add(Math.Round(Sep, 2));
            month.Add(Math.Round(Oct, 2));
            month.Add(Math.Round(Nov, 2));
            month.Add(Math.Round(Dec, 2));
            return month;
        }
    }
}
