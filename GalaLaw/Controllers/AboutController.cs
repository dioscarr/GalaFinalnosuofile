using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaLaw.Models;

namespace GalaLaw.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {

            return View(new AboutUsModel());
        }
    }
}