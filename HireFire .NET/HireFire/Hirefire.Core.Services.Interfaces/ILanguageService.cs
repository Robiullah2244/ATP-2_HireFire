using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetAll();

        IEnumerable<Language> GetByUserName(string userName);

        bool Insert(Language language);
        bool Update(Language language);
        bool Delete(int id);
    }
}
