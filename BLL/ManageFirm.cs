using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageFirm 
    {
        #region Select Methods -- GetAllFirm, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Firm> GetAllFirm()
        {
            return Manage<Firm, FirmRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Firm GetById(int id)
        {
            return Manage<Firm, FirmRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Firm GetById(string id)
        {
            return Manage<Firm, FirmRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddFirm
        public static bool AddFirm(Firm n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Firm, FirmRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateFirm
        public static bool UpdateFirm(Firm n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Firm, FirmRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteFirm
        public static bool DeleteFirm(Firm n)
        {
            n.isDeleted = true;

            return UpdateFirm(n);
        }
        #endregion
    }
}
