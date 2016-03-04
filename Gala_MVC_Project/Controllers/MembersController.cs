using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gala_MVC_Project.Models;
using DAL.Models;

namespace Gala_MVC_Project.Controllers
{
    public class MembersController : Controller
    {
        // GET: Members
        public ActionResult Firm(int? id, string Country)
        {
            ViewBag.country = Country;
            FirmModel FM = new FirmModel(id);
           
            FM.loadFirm((int)id);
            return View(FM);
        }
        public ActionResult MemberList(int? CountryID, int? FirmID, int? memberID)
        {
            MemberModel MM = new MemberModel();            
          
            if (CountryID != null ||FirmID !=null || memberID!=null)
            { MM.LoadMemberList(CountryID,FirmID,memberID);}            
            else {MM.LoadMemberList();}
           

            return View(MM);
        }
        
        public ActionResult Member(int? id, int? FID, string Country)
        {
            using (GalaDBEntities db = new GalaDBEntities()) {
                ViewBag.FID = FID;
                ViewBag.CountryName = Country;

            }
                MemberModel MM = new MemberModel();
            MM.loadMember((int)id);
            return View(MM);
        }

        public ActionResult FirmArchive(int? prevyear, int? nextyear, string type, int FirmID, string Firm) 
        {
            ViewBag.type = type;
            ViewBag.FirmID = FirmID;
            ViewBag.FirmName = Firm;
            EventsModel EM = new EventsModel();
            if (prevyear != null)
            {
                ViewBag.year = Convert.ToInt32(prevyear) - 1;
                ViewBag.PrevYear = Convert.ToInt32(prevyear) - 1;
                ViewBag.NextYear = prevyear - 1;

                EM.LoadFirmnewsByYear(Convert.ToInt32(prevyear) - 1, type,FirmID);
                return View(EM); ;
            }
            else if (nextyear != null)
            {
                ViewBag.year = Convert.ToInt32(nextyear) + 1;
                ViewBag.PrevYear = nextyear + 1;
                ViewBag.NextYear = Convert.ToInt32(nextyear) + 1;

                EM.LoadFirmnewsByYear(Convert.ToInt32(nextyear) + 1, type, FirmID);
                return View(EM);
            }
            else {
                ViewBag.PrevYear = DateTime.Today.Year;
                ViewBag.NextYear = DateTime.Today.Year;
                ViewBag.year = DateTime.Today.Year;
                EM.LoadFirmNewsCurrentYear(DateTime.Today.Year, type, FirmID);
                return View(EM);
            }
            return View(EM);
        }
    }
}