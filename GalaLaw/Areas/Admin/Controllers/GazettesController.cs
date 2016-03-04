using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using GalaLaw.Areas.Admin.Models;

namespace GalaLaw.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class GazettesController : Controller
    {
        private GalaDBEntities db = new GalaDBEntities();

        // GET: Admin/Gazettes
        public ActionResult Index()
        {
            var gazette = db.Gazette.Include(g => g.Firm).Include(g => g.GazetteVolumes).Include(g => g.Team);
            return View(gazette.ToList());
        }

        // GET: Admin/Gazettes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gazette gazette = db.Gazette.Find(id);
            if (gazette == null)
            {
                return HttpNotFound();
            }
            return View(gazette);
        }



        public ActionResult Create()
        {
            ViewBag.Firm = db.Firm.Select(c => new SelectListItem { Text = c.FirmName, Value = c.Id.ToString() }).OrderBy(c=>c.Text).ToList();


            ViewBag.Member = db.Team.Select(c => new SelectListItem { Text = c.FName +" "+ c.LName, Value = c.Id.ToString() }).OrderBy(c => c.Text).ToList();
            ViewBag.GazetteVolumes = db.GazetteVolumes.Select(c => new SelectListItem { Text = c.GazetteVolume, Value = c.Id.ToString() }).OrderBy(c => c.Text).ToList();
            return View(new Gazette());
        }

        [HttpPost]
        [ValidateInput( false)]
        public ActionResult Create(Gazette model)
        {
            GazetteModel GM = new GazetteModel();
            GM.insert(model);
           
            return RedirectToAction("index");
        }


        public ActionResult insertGazetteVolume()
        {
            return View(new GazetteVolumes());
        }
        [HttpPost]
        public ActionResult insertGazetteVolume(GazetteVolumes model)
        {
            GazetteModel GM = new GazetteModel();
            GM.insertGazetteVolume(model);
            return RedirectToAction("index");
        }







        //// GET: Admin/Gazettes/Create
        //public ActionResult Create()
        //{
        //    ViewBag.FirmID = new SelectList(db.Firm, "Id", "FirmName");
        //    ViewBag.GazetteVolumeID = new SelectList(db.GazetteVolumes, "Id", "GazetteVolume");
        //    ViewBag.MemberID = new SelectList(db.Team, "Id", "FName + LName");
        //    return View();
        //}

        //// POST: Admin/Gazettes/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,header,Content,MemberID,GazetteVolumeID,FirmID,Created,Modified,isDeleted")] Gazette gazette)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Gazette.Add(gazette);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.FirmID = new SelectList(db.Firm, "Id", "FirmName", gazette.FirmID);
        //    ViewBag.GazetteVolumeID = new SelectList(db.GazetteVolumes, "Id", "GazetteVolume", gazette.GazetteVolumeID);
        //    ViewBag.MemberID = new SelectList(db.Team, "Id", "Type", gazette.MemberID);
        //    return View(gazette);
        //}

        // GET: Admin/Gazettes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gazette gazette = db.Gazette.Find(id);
            if (gazette == null)
            {
                return HttpNotFound();
            }
            ViewBag.FirmID = new SelectList(db.Firm, "Id", "FirmName", gazette.FirmID);
            ViewBag.GazetteVolumeID = new SelectList(db.GazetteVolumes, "Id", "GazetteVolume", gazette.GazetteVolumeID);
            ViewBag.MemberID = new SelectList(db.Team, "Id", "Type", gazette.MemberID);
            return View(gazette);
        }

        // POST: Admin/Gazettes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,header,Content,MemberID,GazetteVolumeID,FirmID,Created,Modified,isDeleted")] Gazette gazette)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gazette).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FirmID = new SelectList(db.Firm, "Id", "FirmName", gazette.FirmID);
            ViewBag.GazetteVolumeID = new SelectList(db.GazetteVolumes, "Id", "GazetteVolume", gazette.GazetteVolumeID);
            ViewBag.MemberID = new SelectList(db.Team, "Id", "Type", gazette.MemberID);
            return View(gazette);
        }

        // GET: Admin/Gazettes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gazette gazette = db.Gazette.Find(id);
            if (gazette == null)
            {
                return HttpNotFound();
            }
            return View(gazette);
        }

        // POST: Admin/Gazettes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gazette gazette = db.Gazette.Find(id);
            db.Gazette.Remove(gazette);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
