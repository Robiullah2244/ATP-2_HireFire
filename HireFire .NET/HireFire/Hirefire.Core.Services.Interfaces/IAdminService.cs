﻿using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAll();

        IEnumerable<Admin> GetByUserName(string UserName);

        bool Insert(Admin buyer);
        bool Update(Admin buyer);
        bool Delete(string UserName);
    }
}
