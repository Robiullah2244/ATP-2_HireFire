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
        IEnumerable<Gig> GetAllByUserName(string sellerUserName);//Get all the gig information of particluar seller
        IEnumerable<Gig> GetTopGigsByUserName(string sellerUserName);//Get all the gig information of particluar seller by the
                                                                      //order of number order completed

        Gig GetByGigId(int gigId);///For retrieving information of single gig


        IEnumerable<Gig> GetById(string categoryId);

        bool Insert(Gig gig);
        bool Update(Gig gig);//Update Gig By Gig Id 
        bool Delete(int id);  

        string SearchSuggestion(string searchValue, string searchBy);  //it's for real time suggestion

        IEnumerable<Gig> GetBysearchValue(string searchValue, string searchBy);

        IEnumerable<Gig> GetBysearchValueByPrice(string searchValue, int minimum, int maximum); // it's for search by price

        string SearchSuggestionByPrice(string searchValue, int minimum, int maximum);  //it's for real time suggestion for price

        IEnumerable<Gig> GetByCategoryId(int categoryId);




    }
}
