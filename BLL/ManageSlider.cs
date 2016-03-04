using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageSlider 
    {
        #region Select Methods -- GetAllSlider, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Slider> GetAllSlider()
        {
            return Manage<Slider, SliderRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Slider GetById(int id)
        {
            return Manage<Slider, SliderRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Slider GetById(string id)
        {
            return Manage<Slider, SliderRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddSlider
        public static bool AddSlider(Slider n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Slider, SliderRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateSlider
        public static bool UpdateSlider(Slider n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Slider, SliderRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteSlider
        public static bool DeleteSlider(Slider n)
        {
            n.isDeleted = true;

            return UpdateSlider(n);
        }
        #endregion
    }
}
