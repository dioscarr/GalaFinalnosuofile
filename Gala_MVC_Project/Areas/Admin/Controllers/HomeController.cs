using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gala_MVC_Project.Areas.Admin.Models;

namespace Gala_MVC_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {          HomeModel HM = new HomeModel();
        return View(HM);
        }
        [ValidateInput(false)]
        public ActionResult UpdateHomePage(HomeModel model)
        {
            model.update(model);
            return RedirectToAction("index");
        }
        public ActionResult UpdateSliders(HomeModel model)
        {
            model.updateSlider(model);
            return RedirectToAction("index");
        }

   


     //public ActionResult UpdateFirm(FirmModel model)
     //   {
     //       if (model.Firm.isNewPicture)
     //       {
     //           model.Firm.FirmDetail.picture = ImageUloadFirm(model, "~/Images/advisory");
     //       }
          
     //       model.Firm.Update(model);
     //       return RedirectToAction("index");
     //   }

     // //upload image
     //   public string ImageUloadFirm(FirmModel model, string url)
     //   {
     //       var validImageTypes = new string[]
     //       {
     //           "image/gif",
     //           "image/jpeg",
     //           "image/jpg",
     //           "image/pjpeg",
     //           "image/png"
     //       };

     //       if (model.Firm.ImageUpload == null || model.Firm.ImageUpload.ContentLength == 0)
     //       {
     //           ModelState.AddModelError("ImageUpload", "This field is required");
     //       }
     //       else if (!validImageTypes.Contains(model.Firm.ImageUpload.ContentType))
     //       {
     //           ModelState.AddModelError("ImageUpload", "Please choose either a GIF, JPG or PNG image.");
     //       }

     //       if (ModelState.IsValid)
     //       {
     //           if (model.Firm.ImageUpload != null && model.Firm.ImageUpload.ContentLength > 0)
     //           {
     //               var uploadDir = url;
     //               var imagePath = Path.Combine(Server.MapPath(uploadDir), model.Firm.ImageUpload.FileName);
     //               var imageUrl = Path.Combine(uploadDir, model.Firm.ImageUpload.FileName);
     //               model.Firm.ImageUpload.SaveAs(imagePath);
     //               return model.Firm.ImageUpload.FileName;
     //           }
     //       } return "noimg.jpg";
     //   }

    }
}