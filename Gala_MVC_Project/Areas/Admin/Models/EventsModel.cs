using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Models;
using BLL;
using Gala_MVC_Project.Areas.Admin.Models;


namespace Gala_MVC_Project.Areas.Admin.Models
{
    
    public class EventsModel:Basemodel
    {
        GalaDBEntities db = new GalaDBEntities();

         public Events Events { get; set; }
        public List<Events> Eventss { get; set; }          
        public HttpPostedFileBase ImageUpload { get; set; }
        public bool isNewPicture { get; set; }







        public EventsModel()
        {
            Events = null;
            Eventss = ManageEvents.GetAllEvents().OrderBy(c=>c.Type).ToList();         
        }
        
        public void loadEvents(int id) {
            Events = ManageEvents.GetById(id);
        }

        public bool update(EventsModel model)
        {
            return ManageEvents.UpdateEvents(model.Events);
        }

        public bool Insert(EventsModel model)
        {
            return ManageEvents.AddEvents(model.Events);
        }
       
        public bool Delete(int id)
        {
            return ManageEvents.DeleteEvents(ManageEvents.GetById(id));
        }
        
    }

   
}