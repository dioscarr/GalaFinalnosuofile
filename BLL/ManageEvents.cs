using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Models;
using DAL.Repositories;
using System.ComponentModel;




namespace BLL
{
    public class ManageEvents 
    {
        #region Select Methods -- GetAllEvents, GetById
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static IList<Events> GetAllEvents()
        {
            return Manage<Events, EventsRepository>.GetAll().Where(n => n.isDeleted == false).OrderByDescending(n => n.Created).ToList();
        }
        public static Events GetById(int id)
        {
            return Manage<Events, EventsRepository>.GetById(id);
        }
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static Events GetById(string id)
        {
            return Manage<Events, EventsRepository>.GetById(id);
        }
        #endregion

        #region Insert Methods -- AddEvents
        public static bool AddEvents(Events n)
        {
            n.Created = DateTime.Now.Date;
            n.Modified = DateTime.Now.Date;

            return Manage<Events, EventsRepository>.Add(n);
        }
        #endregion

        #region Update Methods -- UpdateEvents
        public static bool UpdateEvents(Events n)
        {

            n.Modified = DateTime.Now.Date;

            return Manage<Events, EventsRepository>.Update(n);
        }
        #endregion

        #region Delete Methods -- DeleteEvents
        public static bool DeleteEvents(Events n)
        {
            n.isDeleted = true;

            return UpdateEvents(n);
        }
        #endregion
    }
}
