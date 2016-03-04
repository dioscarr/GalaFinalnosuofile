using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gala_MVC_Project.Models;

namespace Gala_MVC_Project.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            
            return View(new HomeModel());
        }
        public ActionResult Result()
        {
            return View();
        }
    }

}

    