using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);


        Order MostPopularGig();///By counting the max order then we can get the Most popular gig

        bool Insert(Order order);
        bool Update(Order order);
        bool Delete(int id);
    }
}
