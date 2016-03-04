using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using GalaLaw.Areas.Admin.Models;

namespace GalaLaw.Areas.Admin.Models
{
    public class FirmModel : Basemodel
    {
        GalaDBEntities db = new GalaDBEntities();
        public Firm Firm { get; set; }
        public List<Firm> Firms { get; set; }
        public int MID { get; set; }
        public int FID { get; set; }
        public string CID { get; set; }
        public List<Team> Members { get; set; }
        public FCRelation Fields { get; set; }




        internal void loadFirmById(int id)
        {
            Firm = ManageFirm.GetById(id);
        }





        public FirmModel()
        {
            Firm = null;
            Firms = db.Firm.Where(c => c.isDeleted == false).ToList();


        }
        public bool update(FirmModel model)
        {
            return ManageFirm.UpdateFirm(model.Firm);
        }

        public bool Insert(FirmModel model)
        {
            return ManageFirm.AddFirm(model.Firm);
        }
        public bool Delete(int id)
        {
            return ManageFirm.DeleteFirm(ManageFirm.GetById(id));
        }


        internal void AddFCRelation(FirmModel model)
        {
            ManageFCRelation.AddFCRelation(model.Fields);
          }
    }
    
}
