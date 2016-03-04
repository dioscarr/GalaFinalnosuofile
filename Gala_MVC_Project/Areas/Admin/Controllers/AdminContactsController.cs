using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL.Models;

namespace Gala_MVC_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminContactsController : Controller
    {
         GalaDBEntities db = new GalaDBEntities();
        

        // GET: Admin/Contacts/Edit/5
        public ActionResult Edit(int? id=1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact =  db.Contact.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Admin/Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PageTitle_,Name,Title,CompanyName,Address,City,Zipcode,Tel,fax,Web,Created,Modified,isDeleted")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                 db.SaveChanges();
                return RedirectToAction("Edit");
            }
            return View(contact);
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
