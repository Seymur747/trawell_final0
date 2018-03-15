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
    public class Rent_AmentController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Rent_Ament
        public ActionResult Index()
        {
            var rent_Ament = db.Rent_Ament.Include(r => r.Amenty).Include(r => r.Rental);
            return View(rent_Ament.ToList());
        }

        // GET: Admin/Rent_Ament/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Ament rent_Ament = db.Rent_Ament.Find(id);
            if (rent_Ament == null)
            {
                return HttpNotFound();
            }
            return View(rent_Ament);
        }

        // GET: Admin/Rent_Ament/Create
        public ActionResult Create()
        {
            ViewBag.ament_id = new SelectList(db.Amenties, "id", "names");
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title");
            return View();
        }

        // POST: Admin/Rent_Ament/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rent_id,ament_id")] Rent_Ament rent_Ament)
        {
            if (ModelState.IsValid)
            {
                db.Rent_Ament.Add(rent_Ament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ament_id = new SelectList(db.Amenties, "id", "names", rent_Ament.ament_id);
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Ament.rent_id);
            return View(rent_Ament);
        }

        // GET: Admin/Rent_Ament/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Ament rent_Ament = db.Rent_Ament.Find(id);
            if (rent_Ament == null)
            {
                return HttpNotFound();
            }
            ViewBag.ament_id = new SelectList(db.Amenties, "id", "names", rent_Ament.ament_id);
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Ament.rent_id);
            return View(rent_Ament);
        }

        // POST: Admin/Rent_Ament/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rent_id,ament_id")] Rent_Ament rent_Ament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent_Ament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ament_id = new SelectList(db.Amenties, "id", "names", rent_Ament.ament_id);
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Ament.rent_id);
            return View(rent_Ament);
        }

        // GET: Admin/Rent_Ament/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Ament rent_Ament = db.Rent_Ament.Find(id);
            if (rent_Ament == null)
            {
                return HttpNotFound();
            }
            return View(rent_Ament);
        }

        // POST: Admin/Rent_Ament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent_Ament rent_Ament = db.Rent_Ament.Find(id);
            db.Rent_Ament.Remove(rent_Ament);
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
