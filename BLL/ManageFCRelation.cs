using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageFCRelation 
    {
        #region Select Methods -- GetAllFCRelation, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<FCRelation> GetAllFCRelation()
        {
            return Manage<FCRelation, FCRelationRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created_).ToList();
        }
        public static FCRelation GetById(int id)
        {
            return Manage<FCRelation, FCRelationRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static FCRelation GetById(string id)
        {
            return Manage<FCRelation, FCRelationRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddFCRelation
        public static bool AddFCRelation(FCRelation n)
        {
            n.Created_ = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<FCRelation, FCRelationRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateFCRelation
        public static bool UpdateFCRelation(FCRelation n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<FCRelation, FCRelationRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteFCRelation
        public static bool DeleteFCRelation(FCRelation n)
        {
            n.isDeleted = true;

            return UpdateFCRelation(n);
        }
        #endregion
    }
}
