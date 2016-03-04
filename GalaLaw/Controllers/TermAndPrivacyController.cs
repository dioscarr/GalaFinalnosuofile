using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalaLaw.Controllers
{
    public class TermAndPrivacyController : Controller
    {
        // GET: TermAndPrivacy
        public ActionResult TermOfUse()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}