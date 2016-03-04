using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageHome 
    {
        #region Select Methods -- GetAllHome, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Home> GetAllHome()
        {
            return Manage<Home, HomeRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Home GetById(int id)
        {
            return Manage<Home, HomeRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Home GetById(string id)
        {
            return Manage<Home, HomeRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddHome
        public static bool AddHome(Home n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Home, HomeRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateHome
        public static bool UpdateHome(Home n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Home, HomeRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteHome
        public static bool DeleteHome(Home n)
        {
            n.isDeleted = true;

            return UpdateHome(n);
        }
        #endregion
    }
}
