﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IHeaderService
    {
        dynamic sellerHeaderByUserName(string userName);
        dynamic buyerHeaderByUserName(string userName);
    }
}
