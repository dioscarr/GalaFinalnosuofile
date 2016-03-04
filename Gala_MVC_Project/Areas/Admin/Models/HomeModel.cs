using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
namespace Gala_MVC_Project.Areas.Admin.Models
{
    public class HomeModel
    {
         public Home Home { get; set; }
        public List<Home> Homes { get; set; }
        public List<Slider> Sliders { get; set; }




        public HomeModel()
        {
            Home = ManageHome.GetById(1);
            Homes = null;
            Sliders = ManageSlider.GetAllSlider().ToList();
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