using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);

        bool Insert(Category category);
        bool Update(Category category);
        bool Delete(int id);
    }
}
