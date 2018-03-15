using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.Admin.Controllers
{
    public class Rental_PhotoController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Rental_Photo
        public ActionResult Index()
        {
            var rental_Photo = db.Rental_Photo.Include(r => r.Rental);
            return View(rental_Photo.ToList());
        }

        // GET: Admin/Rental_Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Photo rental_Photo = db.Rental_Photo.Find(id);
            if (rental_Photo == null)
            {
                return HttpNotFound();
            }
            return View(rental_Photo);
        }

        // GET: Admin/Rental_Photo/Create
        public ActionResult Create()
        {
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title");
            return View();
        }

        // POST: Admin/Rental_Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,photo_name,photo_path,rental_id")] Rental_Photo rental_Photo, HttpPostedFileBase photo_path)
        {
            if (ModelState.IsValid)
            {
                if (photo_path.ContentType != "image/png" && photo_path.ContentType != "image/jpg")
                {
                    Session["Erorr"] = "Incorrect format";

                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + photo_path.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Uploads"), filename);
                photo_path.SaveAs(path);
                rental_Photo.photo_path = filename;
                db.Rental_Photo.Add(rental_Photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", rental_Photo.rental_id);
            return View(rental_Photo);
        }

        // GET: Admin/Rental_Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Photo rental_Photo = db.Rental_Photo.Find(id);
            if (rental_Photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", rental_Photo.rental_id);
            return View(rental_Photo);
        }

        // POST: Admin/Rental_Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,photo_name,photo_path,rental_id")] Rental_Photo rental_Photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rental_Photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", rental_Photo.rental_id);
            return View(rental_Photo);
        }

        // GET: Admin/Rental_Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental_Photo rental_Photo = db.Rental_Photo.Find(id);
            if (rental_Photo == null)
            {
                return HttpNotFound();
            }
            return View(rental_Photo);
        }

        // POST: Admin/Rental_Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rental_Photo rental_Photo = db.Rental_Photo.Find(id);
            db.Rental_Photo.Remove(rental_Photo);
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
