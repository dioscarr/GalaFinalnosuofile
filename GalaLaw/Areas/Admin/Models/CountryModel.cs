using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace GalaLaw.Areas.Admin.Models
{
    public class CountryModel
    {
        public Country Country { get; set; }
        public List<Country> Countries { get; set; }




        public CountryModel()
        {
            Country = null;
            Countries = ManageCountry.GetAllCountry().ToList();  
        }
        public bool update(CountryModel model)
        {
            return ManageCountry.UpdateCountry(model.Country);
        }

        public bool Insert(Country model)
        {
            return ManageCountry.AddCountry(model);
        }
        public bool Delete(int id)
        {            
            return ManageCountry.DeleteCountry(ManageCountry.GetById(id));
        }

    }
}