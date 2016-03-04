using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;

namespace Gala_MVC_Project.Models
{
    public class AboutUsModel
    {

        GalaDBEntities db = new GalaDBEntities();

        public  Aboutus aboutus { get; set; }
        public List<Executives> executives { get; set; }




        public AboutUsModel()
        {
            aboutus = ManageAboutus.GetAllAboutus().FirstOrDefault();
          executives = db.Team.Where(c => c.Type == "Executive").Select(c=> new Executives { id = c.Id, Name = c.FName + " " + c.LName, picture = c.Picture, title = c.Title, country = c.CMFRelation.FirstOrDefault().Country.CountryName, FID = c.CMFRelation.FirstOrDefault().Firm.Id }).ToList();
        }
        public bool update(AboutUsModel model)
        {
            return ManageAboutus.UpdateAboutus(model.aboutus);
        }

        public bool Insert(AboutUsModel model)
        {
            return ManageAboutus.AddAboutus(model.aboutus);
        }
        public bool Delete(int id)
        {
            return ManageAboutus.DeleteAboutus(ManageAboutus.GetById(id));
        }

        public class Executives{
            public int id { get; set; }
            public string Name  { get; set; }
            public string  picture  { get; set; }
            public string  title { get; set; }
            public string country { get; set; }
            public int FID { get; set; }
        }

    }
}