using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManagepublicationBooks 
    {
        #region Select Methods -- GetAllpublicationBooks, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<publicationBooks> GetAllpublicationBooks()
        {
            return Manage<publicationBooks, publicationBooksRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static publicationBooks GetById(int id)
        {
            return Manage<publicationBooks, publicationBooksRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static publicationBooks GetById(string id)
        {
            return Manage<publicationBooks, publicationBooksRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddpublicationBooks
        public static bool AddpublicationBooks(publicationBooks n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<publicationBooks, publicationBooksRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdatepublicationBooks
        public static bool UpdatepublicationBooks(publicationBooks n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<publicationBooks, publicationBooksRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeletepublicationBooks
        public static bool DeletepublicationBooks(publicationBooks n)
        {
            n.isDeleted = true;

            return UpdatepublicationBooks(n);
        }
        #endregion
    }
}
