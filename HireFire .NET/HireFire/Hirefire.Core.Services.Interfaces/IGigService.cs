using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IGigService
    {

        IEnumerable<Gig> GetAll();


        IEnumerable<Gig> GetById(int categoryId);

        bool Insert(Gig gig);
        bool Update(Gig gig);
        bool Delete(int id);

        string Search(string search, string searchBy);



    }
}
