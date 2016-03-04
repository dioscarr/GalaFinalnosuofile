using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageGazetteVolumes 
    {
        #region Select Methods -- GetAllGazetteVolumes, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<GazetteVolumes> GetAllGazetteVolumes()
        {
            return Manage<GazetteVolumes, GazetteVolumesRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created_ ).ToList();
        }
        public static GazetteVolumes GetById(int id)
        {
            return Manage<GazetteVolumes, GazetteVolumesRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static GazetteVolumes GetById(string id)
        {
            return Manage<GazetteVolumes, GazetteVolumesRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddGazetteVolumes
        public static bool AddGazetteVolumes(GazetteVolumes n)
        {
            n.Created_ = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<GazetteVolumes, GazetteVolumesRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateGazetteVolumes
        public static bool UpdateGazetteVolumes(GazetteVolumes n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<GazetteVolumes, GazetteVolumesRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteGazetteVolumes
        public static bool DeleteGazetteVolumes(GazetteVolumes n)
        {
            n.isDeleted = true;

            return UpdateGazetteVolumes(n);
        }
        #endregion
    }
}
