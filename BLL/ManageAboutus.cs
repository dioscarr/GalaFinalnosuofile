using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageAboutus 
    {
        #region Select Methods -- GetAllAboutus, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Aboutus> GetAllAboutus()
        {
            return Manage<Aboutus, AboutusRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Aboutus GetById(int id)
        {
            return Manage<Aboutus, AboutusRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Aboutus GetById(string id)
        {
            return Manage<Aboutus, AboutusRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddAboutus
        public static bool AddAboutus(Aboutus n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Aboutus, AboutusRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateAboutus
        public static bool UpdateAboutus(Aboutus n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Aboutus, AboutusRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteAboutus
        public static bool DeleteAboutus(Aboutus n)
        {
            n.isDeleted = true;

            return UpdateAboutus(n);
        }
        #endregion
    }
}
