using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;


namespace Gala_MVC_Project.Models
{
    public class HomeModel:Basemodel
    {
        GalaDBEntities db = new GalaDBEntities();
        public Home Home { get; set; }
        public List<Home> Homes { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<Events> News { get; set; }
        public List<Country> countries { get; set; }
        public List<Firm> Firms { get; set; }
        public List<Team> Teams { get; set; }


        public HomeModel()
        {
            Home = ManageHome.GetById(1);
            Homes = null;
            Sliders = ManageSlider.GetAllSlider().ToList();
            News = db.Events.Where(c=>c.Type=="News").OrderBy(c => c.Published).Take(2).ToList();
            countries = db.CMFRelation.GroupBy(c=>c.Country.Id).Select(x=>x.FirstOrDefault().Country ).ToList();
            Firms = db.CMFRelation.GroupBy(c => c.Country.Id).Select(x => x.FirstOrDefault().Firm).ToList();
            Teams = db.CMFRelation.GroupBy(c => c.Country.Id).Select(x => x.FirstOrDefault().Team).ToList();
        }
        public bool update(HomeModel model)
        {
            return ManageHome.UpdateHome(model.Home);
        }

        public bool Insert(Home model)
        {
            return ManageHome.AddHome(model);
        }
        public bool Delete(int id)
        {
            return ManageHome.DeleteHome(ManageHome.GetById(id));
        }

        public bool updateSlider(HomeModel model)
        {
            try
            {
                foreach (var slider in model.Sliders)
                {
                    ManageSlider.UpdateSlider(slider);
                }
                return true;

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}