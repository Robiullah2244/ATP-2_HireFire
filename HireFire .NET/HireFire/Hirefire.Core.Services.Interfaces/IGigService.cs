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

        string SearchSuggestion(string searchValue, string searchBy);  //it's for real time suggestion

        IEnumerable<Gig> GetBysearchValue(string searchValue, string searchBy);

        IEnumerable<Gig> GetBysearchValueByPrice(string searchValue, int minimum, int maximum); // it's for search by price

        string SearchSuggestionByPrice(string searchValue, int minimum, int maximum);  //it's for real time suggestion for price






    }
}
