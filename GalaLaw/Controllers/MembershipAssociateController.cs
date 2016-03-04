using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GalaLaw.Controllers
{
   
    public class MembershipAssociateController : Controller
    {
        // GET: MembershipAssociate
        public ActionResult MembershipAssociate()
        {
            return View();
        }
        [Authorize(Roles = "Associate")]
        public ActionResult WelcomeMembershipAssociate()
        {
            return View();
        }
    }
}