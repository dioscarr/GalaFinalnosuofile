using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gala_MVC_Project.Areas.Admin.Models;
using System.IO;

namespace Gala_MVC_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPublicationController : Controller
    {
        // GET: Admin/AdminPublication
        public ActionResult Index()
        {
           
            return View(new PublicationModel());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(PublicationModel model)
        {
            model.update(model);
            return RedirectToAction("index");
        }

        public ActionResult insert()
        {
            return View(new PublicationModel());
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult insert(PublicationModel model)
        {
            model.publicationbook.Picture = ImageUloadPM(model, "~/Images/publications");
            model.insert(model);
            return RedirectToAction("index");
        }

        public ActionResult Edit(int id)
        {
            PublicationModel PM = new PublicationModel();

            PM.loadPBook(id);
            return View(PM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(PublicationModel model)
        {
             if (model.isNewPicture)
            {
                model.publicationbook.Picture = ImageUloadPM(model, "~/Images/publications");
            }

            model.updateBook(model);
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            PublicationModel PM = new PublicationModel();
            PM.Delete(id);
            return RedirectToAction("index");
        }


        //upload image
        public string ImageUloadPM(PublicationModel model, string url)
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
            }
            return "noimg.jpg";
        }
            }
}