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
    public class Cars_FeatController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Cars_Feat
        public ActionResult Index()
        {
            var cars_Feat = db.Cars_Feat.Include(c => c.Car).Include(c => c.Feature);
            return View(cars_Feat.ToList());
        }

        // GET: Admin/Cars_Feat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Feat cars_Feat = db.Cars_Feat.Find(id);
            if (cars_Feat == null)
            {
                return HttpNotFound();
            }
            return View(cars_Feat);
        }

        // GET: Admin/Cars_Feat/Create
        public ActionResult Create()
        {
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name");
            ViewBag.feat_id = new SelectList(db.Features, "id", "names");
            return View();
        }

        // POST: Admin/Cars_Feat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,feat_id,cars_id")] Cars_Feat cars_Feat)
        {
            if (ModelState.IsValid)
            {
                db.Cars_Feat.Add(cars_Feat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Feat.cars_id);
            ViewBag.feat_id = new SelectList(db.Features, "id", "names", cars_Feat.feat_id);
            return View(cars_Feat);
        }

        // GET: Admin/Cars_Feat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Feat cars_Feat = db.Cars_Feat.Find(id);
            if (cars_Feat == null)
            {
                return HttpNotFound();
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Feat.cars_id);
            ViewBag.feat_id = new SelectList(db.Features, "id", "names", cars_Feat.feat_id);
            return View(cars_Feat);
        }

        // POST: Admin/Cars_Feat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,feat_id,cars_id")] Cars_Feat cars_Feat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_Feat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Feat.cars_id);
            ViewBag.feat_id = new SelectList(db.Features, "id", "names", cars_Feat.feat_id);
            return View(cars_Feat);
        }

        // GET: Admin/Cars_Feat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Feat cars_Feat = db.Cars_Feat.Find(id);
            if (cars_Feat == null)
            {
                return HttpNotFound();
            }
            return View(cars_Feat);
        }

        // POST: Admin/Cars_Feat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_Feat cars_Feat = db.Cars_Feat.Find(id);
            db.Cars_Feat.Remove(cars_Feat);
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
