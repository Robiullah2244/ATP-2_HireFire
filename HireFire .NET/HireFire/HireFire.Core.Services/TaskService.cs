using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace HireFire.Core.Services
{
    public class TaskService : ITaskService
    {
        DbContext _context;

        public TaskService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Entity.Task> GetAllByOrderId(int orderId)
        {
            return _context.Set<Task>().Where(o => o.OrderId == orderId);
        }

        public Entity.Task GetById(int taskId)
        {
            return _context.Set<Task>().Where(t => t.Id == taskId).FirstOrDefault();
        }

        public bool Insert(Entity.Task task)
        {
            try
            {
                task.Status = 1;
                task.Approbation = false;
                _context.Set<Task>().Add(task);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Entity.Task task)
        {
            try
            {
                var targetTask = _context.Set<Task>().Where(t => t.Id == task.Id).FirstOrDefault();
                targetTask.Approbation = task.Approbation;
                targetTask.TaskName = task.TaskName;
                targetTask.Deadline = task.Deadline;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool UpdateFileName(Entity.Task task)
        {
            try
            {
                var targetTask = _context.Set<Task>().Where(t => t.Id == task.Id).FirstOrDefault();
                targetTask.FileName = task.FileName;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }


        
        public bool Delete(int taskId)
        {
            throw new NotImplementedException();
        }

        public int NumberOfActiveTaskByUserName(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
