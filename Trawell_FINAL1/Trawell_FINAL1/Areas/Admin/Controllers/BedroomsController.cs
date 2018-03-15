using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.Admin.Controllers
{
    public class BedroomsController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Bedrooms
        public ActionResult Index()
        {
            var bedrooms = db.Bedrooms.Include(b => b.Rental);
            return View(bedrooms.ToList());
        }

        // GET: Admin/Bedrooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedroom bedroom = db.Bedrooms.Find(id);
            if (bedroom == null)
            {
                return HttpNotFound();
            }
            return View(bedroom);
        }

        // GET: Admin/Bedrooms/Create
        public ActionResult Create()
        {
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title");
            return View();
        }

        // POST: Admin/Bedrooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bed_num,rental_id")] Bedroom bedroom)
        {
            if (ModelState.IsValid)
            {
                db.Bedrooms.Add(bedroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", bedroom.rental_id);
            return View(bedroom);
        }

        // GET: Admin/Bedrooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedroom bedroom = db.Bedrooms.Find(id);
            if (bedroom == null)
            {
                return HttpNotFound();
            }
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", bedroom.rental_id);
            return View(bedroom);
        }

        // POST: Admin/Bedrooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bed_num,rental_id")] Bedroom bedroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bedroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rental_id = new SelectList(db.Rentals, "id", "title", bedroom.rental_id);
            return View(bedroom);
        }

        // GET: Admin/Bedrooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bedroom bedroom = db.Bedrooms.Find(id);
            if (bedroom == null)
            {
                return HttpNotFound();
            }
            return View(bedroom);
        }

        // POST: Admin/Bedrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bedroom bedroom = db.Bedrooms.Find(id);
            db.Bedrooms.Remove(bedroom);
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
