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
    public class Cars_DefEquipController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Cars_DefEquip
        public ActionResult Index()
        {
            var cars_DefEquip = db.Cars_DefEquip.Include(c => c.Car).Include(c => c.Default_Equipment);
            return View(cars_DefEquip.ToList());
        }

        // GET: Admin/Cars_DefEquip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_DefEquip cars_DefEquip = db.Cars_DefEquip.Find(id);
            if (cars_DefEquip == null)
            {
                return HttpNotFound();
            }
            return View(cars_DefEquip);
        }

        // GET: Admin/Cars_DefEquip/Create
        public ActionResult Create()
        {
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name");
            ViewBag.def_equip_id = new SelectList(db.Default_Equipment, "id", "def_name");
            return View();
        }

        // POST: Admin/Cars_DefEquip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,def_equip_id,cars_id")] Cars_DefEquip cars_DefEquip)
        {
            if (ModelState.IsValid)
            {
                db.Cars_DefEquip.Add(cars_DefEquip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_DefEquip.cars_id);
            ViewBag.def_equip_id = new SelectList(db.Default_Equipment, "id", "def_name", cars_DefEquip.def_equip_id);
            return View(cars_DefEquip);
        }

        // GET: Admin/Cars_DefEquip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_DefEquip cars_DefEquip = db.Cars_DefEquip.Find(id);
            if (cars_DefEquip == null)
            {
                return HttpNotFound();
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_DefEquip.cars_id);
            ViewBag.def_equip_id = new SelectList(db.Default_Equipment, "id", "def_name", cars_DefEquip.def_equip_id);
            return View(cars_DefEquip);
        }

        // POST: Admin/Cars_DefEquip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,def_equip_id,cars_id")] Cars_DefEquip cars_DefEquip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_DefEquip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_DefEquip.cars_id);
            ViewBag.def_equip_id = new SelectList(db.Default_Equipment, "id", "def_name", cars_DefEquip.def_equip_id);
            return View(cars_DefEquip);
        }

        // GET: Admin/Cars_DefEquip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_DefEquip cars_DefEquip = db.Cars_DefEquip.Find(id);
            if (cars_DefEquip == null)
            {
                return HttpNotFound();
            }
            return View(cars_DefEquip);
        }

        // POST: Admin/Cars_DefEquip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_DefEquip cars_DefEquip = db.Cars_DefEquip.Find(id);
            db.Cars_DefEquip.Remove(cars_DefEquip);
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
