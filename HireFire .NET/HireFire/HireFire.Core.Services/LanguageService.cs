using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireFire.Core.Services
{
    class LanguageService //: ILanguageService
    {
        DbContext _context;
        public LanguageService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Language> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Language> GetByUserName(int userName)
        {
            //return _context.Set<Language>().Where(l => l.UserName == userName);
            throw new NotImplementedException();
        }

        public bool Insert(Language language)
        {
            try
            {
                _context.Set<Language>().Add(language);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Language language)
        {
            try
            {
                //_context.Set<Language>().
                //_context.SaveChanges();
                //return true;
            }
            catch
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
