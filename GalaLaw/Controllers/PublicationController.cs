using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaLaw.Models;

namespace GalaLaw.Controllers
{
    public class PublicationController : Controller
    {
        // GET: Publication
        public ActionResult Publication()
        {
            PublicationModel PM = new PublicationModel();
            return View(PM);
        }
        public ActionResult GazetteArchive(int? id, int? firmID)
        {
            ViewBag.Firm = firmID;
            PublicationModel PM = new PublicationModel();
            if (firmID != null)
            {
                PM.loadGazettebyVolume(null,firmID);
                return View(PM);
            }
            else {                               
                PM.loadGazettebyVolume(id, null);
                return View(PM);
            }
        }


        public ActionResult GazetteArticle(int id)
        {
            PublicationModel PM = new PublicationModel();
            PM.GazetteArticle = PM.GazetteArticles.Where(c => c.Id == id).FirstOrDefault();
            return View(PM);           
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GazetteVolumes(int? firmID)
        {
            PublicationModel PM = new PublicationModel();
            if (firmID != null)
            {
                PM.publicationFirm(firmID);
                var mymodel1 = Json(PM.mymodel);
                return new JsonResult() { Data = mymodel1, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            
            var mymodel = Json(PM.mymodel);
            return new JsonResult() { Data = mymodel, JsonRequestBehavior = JsonRequestBehavior.AllowGet };


        }
    }
}