using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
namespace Gala_MVC_Project.Areas.Admin.Models
{
    public class GazetteModel
    {
        public Gazette gazette { get; set; }
        public List<GazetteVolumes> listGazetteVolumes { set; get; }


        public GazetteModel() {

            gazette = null;
           
        }

        internal void insert(Gazette model)
        {
            ManageGazette.AddGazette(model);
        }

        internal void insertGazetteVolume(GazetteVolumes model)
        {
            ManageGazetteVolumes.AddGazetteVolumes(model);
        }
    }
}