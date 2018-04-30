using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ITaskCommentService
    {
        IEnumerable<TaskComment> GetAllByTaskId(int taskId);///Calling Task Comment Table
        //TaskComment GetById(int Id);
        bool Insert(TaskComment taskComment);
        //bool Update(TaskComment taskcomment);
        //bool Delete(int Id);

        bool DeleteAllByTaskId(int taskId); //when a task is deleted then all the comment of this task will be deleted.
    }
}
