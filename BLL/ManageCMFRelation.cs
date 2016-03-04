using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageCMFRelation 
    {
        #region Select Methods -- GetAllCMFRelation, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<CMFRelation> GetAllCMFRelation()
        {
            return Manage<CMFRelation, CMFRelationRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static CMFRelation GetById(int id)
        {
            return Manage<CMFRelation, CMFRelationRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static CMFRelation GetById(string id)
        {
            return Manage<CMFRelation, CMFRelationRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddCMFRelation
        public static bool AddCMFRelation(CMFRelation n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<CMFRelation, CMFRelationRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateCMFRelation
        public static bool UpdateCMFRelation(CMFRelation n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<CMFRelation, CMFRelationRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteCMFRelation
        public static bool DeleteCMFRelation(CMFRelation n)
        {
            n.isDeleted = true;

            return UpdateCMFRelation(n);
        }
        #endregion
    }
}
