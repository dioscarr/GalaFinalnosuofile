using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageCountry 
    {
        #region Select Methods -- GetAllCountry, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Country> GetAllCountry()
        {
            return Manage<Country, CountryRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Country GetById(int id)
        {
            return Manage<Country, CountryRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Country GetById(string id)
        {
            return Manage<Country, CountryRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddCountry
        public static bool AddCountry(Country n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Country, CountryRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateCountry
        public static bool UpdateCountry(Country n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Country, CountryRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteCountry
        public static bool DeleteCountry(Country n)
        {
            n.isDeleted = true;

            return UpdateCountry(n);
        }
        #endregion
    }
}
