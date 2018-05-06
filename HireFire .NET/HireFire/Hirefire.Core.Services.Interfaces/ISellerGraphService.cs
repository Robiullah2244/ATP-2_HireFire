﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ISellerGraphService
    {
        IEnumerable<double> LastYearIncomeGraphByUserName(string sellerUserName);
    }
}
