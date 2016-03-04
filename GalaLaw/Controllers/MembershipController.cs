using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalaLaw.Controllers
{   
    public class MembershipController : Controller
    {
        // GET: Membership
        public ActionResult Membership()
        {
            return View();
        }
        [Authorize(Roles = "Member")]
        public ActionResult WelcomeMembership()
        {
            return View();
        }
    }
}