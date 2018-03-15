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
    public class Cars_PIckupFeatController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Cars_PIckupFeat
        public ActionResult Index()
        {
            var cars_PIckupFeat = db.Cars_PIckupFeat.Include(c => c.Car).Include(c => c.PickUp_Features);
            return View(cars_PIckupFeat.ToList());
        }

        // GET: Admin/Cars_PIckupFeat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_PIckupFeat cars_PIckupFeat = db.Cars_PIckupFeat.Find(id);
            if (cars_PIckupFeat == null)
            {
                return HttpNotFound();
            }
            return View(cars_PIckupFeat);
        }

        // GET: Admin/Cars_PIckupFeat/Create
        public ActionResult Create()
        {
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name");
            ViewBag.pickupfeat_id = new SelectList(db.PickUp_Features, "id", "pickup_name");
            return View();
        }

        // POST: Admin/Cars_PIckupFeat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pickupfeat_id,cars_id")] Cars_PIckupFeat cars_PIckupFeat)
        {
            if (ModelState.IsValid)
            {
                db.Cars_PIckupFeat.Add(cars_PIckupFeat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_PIckupFeat.cars_id);
            ViewBag.pickupfeat_id = new SelectList(db.PickUp_Features, "id", "pickup_name", cars_PIckupFeat.pickupfeat_id);
            return View(cars_PIckupFeat);
        }

        // GET: Admin/Cars_PIckupFeat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_PIckupFeat cars_PIckupFeat = db.Cars_PIckupFeat.Find(id);
            if (cars_PIckupFeat == null)
            {
                return HttpNotFound();
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_PIckupFeat.cars_id);
            ViewBag.pickupfeat_id = new SelectList(db.PickUp_Features, "id", "pickup_name", cars_PIckupFeat.pickupfeat_id);
            return View(cars_PIckupFeat);
        }

        // POST: Admin/Cars_PIckupFeat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pickupfeat_id,cars_id")] Cars_PIckupFeat cars_PIckupFeat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_PIckupFeat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_PIckupFeat.cars_id);
            ViewBag.pickupfeat_id = new SelectList(db.PickUp_Features, "id", "pickup_name", cars_PIckupFeat.pickupfeat_id);
            return View(cars_PIckupFeat);
        }

        // GET: Admin/Cars_PIckupFeat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_PIckupFeat cars_PIckupFeat = db.Cars_PIckupFeat.Find(id);
            if (cars_PIckupFeat == null)
            {
                return HttpNotFound();
            }
            return View(cars_PIckupFeat);
        }

        // POST: Admin/Cars_PIckupFeat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_PIckupFeat cars_PIckupFeat = db.Cars_PIckupFeat.Find(id);
            db.Cars_PIckupFeat.Remove(cars_PIckupFeat);
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
