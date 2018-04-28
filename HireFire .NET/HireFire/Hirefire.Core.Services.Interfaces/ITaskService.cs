﻿using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<Task> GetAll(string orderId);///Calling the Task Table
        //Task GetById(int taskId);
        bool Insert(Task task);
        bool Update(Task task);
        bool Delete(int taskId);
                                              
        
    }
}