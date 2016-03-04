using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManagePublication 
    {
        #region Select Methods -- GetAllPublication, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Publication> GetAllPublication()
        {
            return Manage<Publication, PublicationRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Publication GetById(int id)
        {
            return Manage<Publication, PublicationRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Publication GetById(string id)
        {
            return Manage<Publication, PublicationRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddPublication
        public static bool AddPublication(Publication n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Publication, PublicationRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdatePublication
        public static bool UpdatePublication(Publication n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Publication, PublicationRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeletePublication
        public static bool DeletePublication(Publication n)
        {
            n.isDeleted = true;

            return UpdatePublication(n);
        }
        #endregion
    }
}
