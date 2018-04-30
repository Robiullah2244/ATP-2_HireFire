using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IRatingInterface
    {
        double AverageGigRatingByGigId(int gigId);  //Gig Rating
        double AverageSellerRatingBySellerUserName(string userName);  //Seller Overall Rating
        bool Update(int orderId);   //Order table has by default null value. When Buyer Give rating then Rating will be Updated in Order table


    }
}
