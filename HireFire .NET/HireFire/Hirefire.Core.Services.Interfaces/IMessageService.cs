using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetByUserName(string fromUser, string toUser);

        bool Insert(Message message);

        //bool Update(Message message);
        //bool Delete(int id);
    }
}
