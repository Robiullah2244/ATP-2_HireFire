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
            throw new NotImplementedException();
        }

        public bool Insert(Entity.Task task)
        {
            try
            {
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
            throw new NotImplementedException();
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
