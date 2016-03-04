using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageGazette 
    {
        #region Select Methods -- GetAllGazette, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Gazette> GetAllGazette()
        {
            return Manage<Gazette, GazetteRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Gazette GetById(int id)
        {
            return Manage<Gazette, GazetteRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Gazette GetById(string id)
        {
            return Manage<Gazette, GazetteRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddGazette
        public static bool AddGazette(Gazette n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Gazette, GazetteRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateGazette
        public static bool UpdateGazette(Gazette n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Gazette, GazetteRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteGazette
        public static bool DeleteGazette(Gazette n)
        {
            n.isDeleted = true;

            return UpdateGazette(n);
        }
        #endregion
    }
}
