using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gala_MVC_Project.Models;

namespace Gala_MVC_Project.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult NewList()
        {
            EventsModel EM = new EventsModel();
            EM.Loadnews();
            EM.LoadPress();
            return View(EM);
        }
        public ActionResult NewsArchive(int? prevyear, int? nextyear, string type)
        {
            ViewBag.type = type;
            EventsModel EM = new EventsModel();
            if (prevyear != null)
            {
                ViewBag.year = Convert.ToInt32(prevyear) - 1;
                ViewBag.PrevYear = Convert.ToInt32(prevyear) - 1;
                ViewBag.NextYear = prevyear - 1;

                EM.LoadnewsByYear(Convert.ToInt32(prevyear) - 1, type);
                return View(EM);;
            }
            else if(nextyear!=null)
            {
                ViewBag.year = Convert.ToInt32(nextyear) + 1;
                ViewBag.PrevYear = nextyear + 1;
                ViewBag.NextYear = Convert.ToInt32(nextyear) + 1;

                EM.LoadnewsByYear(Convert.ToInt32(nextyear) + 1, type);
                return View(EM);
            }
            else {
                ViewBag.PrevYear = DateTime.Today.Year;
                ViewBag.NextYear = DateTime.Today.Year;
                ViewBag.year = DateTime.Today.Year;
                EM.LoadNewsCurrentYear(DateTime.Today.Year,type);
                return View(EM);
            }
            return View(EM);
        }

        public ActionResult PressArchive()
        {
            EventsModel EM = new EventsModel();
            EM.LoadPress();
            return View(EM);
        }

        public ActionResult NewsArticle(int id)
        {
            EventsModel EM = new EventsModel();
            EM.LoadnewsBy(id);
            return View(EM);
        }
    }
}