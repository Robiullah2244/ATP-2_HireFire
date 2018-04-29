using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetByUserName(string userName);
        bool Insert(User user);
        bool Update(User user);
        bool Delete(string userName);

        bool IsValid(string userName, string password);

    }
}
