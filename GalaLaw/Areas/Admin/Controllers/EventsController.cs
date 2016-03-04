using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GalaLaw.Areas.Admin.Models;
using BLL;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace GalaLaw.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventsController : Controller
    {
        // GET: Admin/Events
        public ActionResult Index()
        {
            EventsModel EM = new EventsModel();

            return View(EM);
        }
        public ActionResult Delete(int id)
        {
            EventsModel EM = new EventsModel();
            EM.Delete(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            List<SelectListItem> type = new List<SelectListItem>();
            type.Add(new SelectListItem { Text = "News", Value = "News" });
            type.Add(new SelectListItem { Text = "Gala Events", Value = "Gala Events" });
            type.Add(new SelectListItem { Text = "Press", Value = "Press" });
            type.Add(new SelectListItem { Text = "Other Events", Value = "Other Events" });

            CountryModel CM = new CountryModel();
            ViewBag.Members = ManageTeam.GetAllTeam().Select(c => new SelectListItem { Text = c.FName + " " + c.LName, Value = c.Id.ToString() }).ToList();
            ViewBag.type = type;//list of type 
            ViewBag.Firms = ManageFirm.GetAllFirm().GroupBy(x => x.FirmName).Select(c => new SelectListItem { Text = c.FirstOrDefault().FirmName, Value = c.FirstOrDefault().Id.ToString() }).ToList();// get list of firms
        
            EventsModel EM = new EventsModel();
            EM.loadEvents(id);
            return View(EM);
        }
        [HttpPost]
       [ValidateInput(false)]
        public ActionResult Update(EventsModel model, HttpPostedFileBase ImageUpload, bool isNewPicture)
        {
            model.update(model);
            return RedirectToAction("index");
        }
        public ActionResult Insert()
        {
            List<SelectListItem> type = new List<SelectListItem>();
            type.Add(new SelectListItem { Text = "News", Value = "News" });
            type.Add(new SelectListItem { Text = "Gala Events", Value = "Gala Events" });
            type.Add(new SelectListItem { Text = "Press", Value = "Press" });
            type.Add(new SelectListItem { Text = "Other Events", Value = "Other Events" });
           
            CountryModel CM = new CountryModel();
            ViewBag.Members = ManageTeam.GetAllTeam().Select(c => new SelectListItem { Text = c.FName + " " + c.LName, Value = c.Id.ToString() }).OrderBy(x=>x.Text).ToList();
            ViewBag.type = type;//list of type 
            ViewBag.Firms = ManageFirm.GetAllFirm().GroupBy(x => x.FirmName).Select(c => new SelectListItem { Text = c.FirstOrDefault().FirmName, Value = c.FirstOrDefault().Id.ToString() }).OrderBy(x => x.Text).ToList();// get list of firms
            return View();

        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Insert(EventsModel model, HttpPostedFileBase ImageUpload, bool isNewPicture)
        {

            if (isNewPicture)
            {
                model.Events.Content = "<a href='/Images/Media/"+ UploadPDF(model, "~/Images/Media") + "' class='eventlink'>" + model.Events.Heading +"</a>"; ;

            }
            model.Insert(model);
            return RedirectToAction("index");
        }
        public ActionResult Details(int id)
        {
            EventsModel EM = new EventsModel();
            EM.loadEvents(id);

            return View(EM);
        }

        //upload image
        public string UploadPDF(EventsModel model, string url)
        {
            var validImageTypes = new string[]
            {
                "image/gif",
                "image/jpeg",
                "image/jpg",
                "image/pjpeg",
                "image/png",
                "application/pdf"
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
            }
            return "noimg.jpg";
        }

    }
}