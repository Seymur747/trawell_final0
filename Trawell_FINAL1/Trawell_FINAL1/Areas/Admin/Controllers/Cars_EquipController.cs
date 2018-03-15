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
    public class Cars_EquipController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Cars_Equip
        public ActionResult Index()
        {
            var cars_Equip = db.Cars_Equip.Include(c => c.Car).Include(c => c.Equipment);
            return View(cars_Equip.ToList());
        }

        // GET: Admin/Cars_Equip/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Equip cars_Equip = db.Cars_Equip.Find(id);
            if (cars_Equip == null)
            {
                return HttpNotFound();
            }
            return View(cars_Equip);
        }

        // GET: Admin/Cars_Equip/Create
        public ActionResult Create()
        {
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name");
            ViewBag.equipm_id = new SelectList(db.Equipments, "id", "equipment_Name");
            return View();
        }

        // POST: Admin/Cars_Equip/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,cars_id,equipm_id")] Cars_Equip cars_Equip)
        {
            if (ModelState.IsValid)
            {
                db.Cars_Equip.Add(cars_Equip);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Equip.cars_id);
            ViewBag.equipm_id = new SelectList(db.Equipments, "id", "equipment_Name", cars_Equip.equipm_id);
            return View(cars_Equip);
        }

        // GET: Admin/Cars_Equip/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Equip cars_Equip = db.Cars_Equip.Find(id);
            if (cars_Equip == null)
            {
                return HttpNotFound();
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Equip.cars_id);
            ViewBag.equipm_id = new SelectList(db.Equipments, "id", "equipment_Name", cars_Equip.equipm_id);
            return View(cars_Equip);
        }

        // POST: Admin/Cars_Equip/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,cars_id,equipm_id")] Cars_Equip cars_Equip)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_Equip).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cars_id = new SelectList(db.Cars, "id", "car_Name", cars_Equip.cars_id);
            ViewBag.equipm_id = new SelectList(db.Equipments, "id", "equipment_Name", cars_Equip.equipm_id);
            return View(cars_Equip);
        }

        // GET: Admin/Cars_Equip/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_Equip cars_Equip = db.Cars_Equip.Find(id);
            if (cars_Equip == null)
            {
                return HttpNotFound();
            }
            return View(cars_Equip);
        }

        // POST: Admin/Cars_Equip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_Equip cars_Equip = db.Cars_Equip.Find(id);
            db.Cars_Equip.Remove(cars_Equip);
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
