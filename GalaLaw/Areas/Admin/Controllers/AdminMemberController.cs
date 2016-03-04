using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaLaw.Areas.Admin.Models;
using DAL.Models;
using BLL;
using System.IO;

namespace GalaLaw.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMemberController : Controller
    {
        // GET: Admin/Member
        public ActionResult MemberList()
        {

            MemberModel MM = new MemberModel();
          MM.LoadMemberList();
            
            return View(MM);
        }
        [HttpGet]
        public ActionResult AddNewMember()
        {
            CountryModel CM = new CountryModel();
            ViewBag.Countries = CM.Countries.Select(c => new SelectListItem { Text = c.CountryName, Value = c.Id.ToString() }).ToList();//get list of country
            ViewBag.Firms = ManageFirm.GetAllFirm().GroupBy(x => x.FirmName).Select(c => new SelectListItem { Text = c.FirstOrDefault().FirmName, Value = c.FirstOrDefault().Id.ToString() }).ToList();// get list of firms
          
            List<SelectListItem> type = new List<SelectListItem>();
            type.Add(new SelectListItem { Text = "Member", Value = "Member" });
            type.Add(new SelectListItem { Text = "Executive", Value = "Executive" });
            ViewBag.type = type;//list of type 
            return View(new MemberModel());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewMember(MemberModel model, HttpPostedFileBase ImageUpload)
        {
            try
            {
                if (model.isNewPicture)
                {
                    model.Member.Picture = ImageUloadFirm(model, "~/Images/Members");
                }

               
                model.Insert(model);
              
                return RedirectToAction("MemberList");
            }
            catch (Exception)
            {

                throw;
            }

        }
        public JsonResult getFirm(string Country)
        {
            var Firms = ManageFirm.GetAllFirm().Where(c => c.Country == Country).Select(c => new SelectListItem { Text = c.FirmName, Value = c.Id.ToString() }).ToList();// get list of firms 
            return new JsonResult() { Data = Firms, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult DeleteRef(int id, int MID)
        {
            ManageTeam.DeleteTeam(ManageTeam.GetById(MID));
            MemberModel MM = new MemberModel();
            MM.DeleteRef(id);
            return RedirectToAction("MemberList");
        }
        public ActionResult Details(int id)
        {
            MemberModel MM = new MemberModel();
            MM.loadMember(id);
            return View(MM);            
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {

            List<SelectListItem> type = new List<SelectListItem>();
            type.Add(new SelectListItem { Text = "Member", Value = "Member" });
            type.Add(new SelectListItem { Text = "Executive", Value = "Executive" });
            ViewBag.type = type;//list of type 
            MemberModel MM = new MemberModel();
            MM.loadMember(id);
            return View(MM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(MemberModel model)
        {

            if (model.isNewPicture)
            {
                model.Member.Picture = ImageUloadFirm(model, "~/Images/Members");
            }
            model.update(model);
            return RedirectToAction("MemberList");
        }
        public string ImageUloadFirm(MemberModel model, string url)
        {
            var validImageTypes = new string[]
               {
                   "image/gif",
                   "image/jpeg",
                   "image/jpg",
                   "image/pjpeg",
                   "image/png"
               };

            if (model.ImageUpload == null || model.ImageUpload.ContentLength == 0)
            {
                ModelState.AddModelError("ImageUpload", "This field is required");
            }
            else if (!validImageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
            }

            if (ModelState.IsValid)
            {
                if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                {
                    var uploadDir = url;
                    var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
                    var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
                    model.ImageUpload.SaveAs(imagePath);
                    return model.ImageUpload.FileName;
                }
            } return "noimg.jpg";

        }   
    }
}