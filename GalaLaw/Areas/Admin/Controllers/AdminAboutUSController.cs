using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaLaw.Areas.Admin.Models;
namespace GalaLaw.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminAboutUSController : Controller
    {
        
        public ActionResult Index()
        {
            return View(new AboutusModel());
        }

        [HttpPost]
        
        public ActionResult Index(AboutusModel model)
        {
            model.update(model);
            return RedirectToAction("index");
        }
    }
}