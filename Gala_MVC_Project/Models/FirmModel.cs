using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace Gala_MVC_Project.Models
{
    public class FirmModel:Basemodel
    {
        GalaDBEntities db = new GalaDBEntities();
        public Firm Firm { get; set; }
        public List<Firm> Firms { get; set; }
        public List<Events> Media { get; set; }
        public List<Gazette> Gazettes { get; set; }



        public FirmModel(int? id)
        {
            Firm = null;
            Firms = ManageFirm.GetAllFirm().ToList();
            Gazettes = db.Gazette.Where(c => c.FirmID == id).ToList();
        }

      


        public void loadFirm(int id)
        {
            Firm = db.Firm.Where(c => c.Id == id).FirstOrDefault();
            Media = db.Events.Where(c => c.FirmID == id).ToList();
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

    }
}