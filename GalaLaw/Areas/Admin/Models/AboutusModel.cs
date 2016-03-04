using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;


namespace GalaLaw.Areas.Admin.Models
{
    public class AboutusModel
     {
        public  Aboutus aboutus { get; set; }
        public List<Team> Executives { get; set; }




        public AboutusModel()
        {
            aboutus = ManageAboutus.GetAllAboutus().FirstOrDefault();
            Executives = ManageTeam.GetAllTeam().Where(c => c.Type == "Executive").ToList();
        }
        public bool update(AboutusModel model)
        {
            return ManageAboutus.UpdateAboutus(model.aboutus);
        }

        public bool Insert(AboutusModel model)
        {
            return ManageAboutus.AddAboutus(model.aboutus);
        }
        public bool Delete(int id)
        {
            return ManageAboutus.DeleteAboutus(ManageAboutus.GetById(id));
        }

    }
}