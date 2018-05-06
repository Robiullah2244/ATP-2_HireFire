using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HireFire.Web.Mvc.Models
{
    public class ReturnCategoryId
    {
        public int ReturnCategoryIdByCategoryName(string category)
        {
            if(category=="Digital Marketing"){
                return 1;
            }
            else if(category=="Writing & Translation"){
                return 2;
            }
            else if (category == "Video & Animation")
            {
                return 3;
            }
            else if (category == "Programming & Tech")
            {
                return 4;
            }
            else if (category == "Business")
            {
                return 5;
            }
            else if (category == "Music & Audio")
            {
                return 6;
            }
            else 
            {
                return 7;
            }
        }
    }
}