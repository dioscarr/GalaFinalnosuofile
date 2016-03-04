using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageGMLink 
    {
        #region Select Methods -- GetAllGMLink, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<GMLink> GetAllGMLink()
        {
            return Manage<GMLink, GMLinkRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created_).ToList();
        }
        public static GMLink GetById(int id)
        {
            return Manage<GMLink, GMLinkRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static GMLink GetById(string id)
        {
            return Manage<GMLink, GMLinkRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddGMLink
        public static bool AddGMLink(GMLink n)
        {
            n.Created_ = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<GMLink, GMLinkRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateGMLink
        public static bool UpdateGMLink(GMLink n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<GMLink, GMLinkRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteGMLink
        public static bool DeleteGMLink(GMLink n)
        {
            n.isDeleted = true;

            return UpdateGMLink(n);
        }
        #endregion
    }
}
