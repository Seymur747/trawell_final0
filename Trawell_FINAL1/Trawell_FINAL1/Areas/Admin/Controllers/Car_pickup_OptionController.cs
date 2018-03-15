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
    public class Car_pickup_OptionController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Car_pickup_Option
        public ActionResult Index()
        {
            return View(db.Car_pickup_Option.ToList());
        }

        // GET: Admin/Car_pickup_Option/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_pickup_Option car_pickup_Option = db.Car_pickup_Option.Find(id);
            if (car_pickup_Option == null)
            {
                return HttpNotFound();
            }
            return View(car_pickup_Option);
        }

        // GET: Admin/Car_pickup_Option/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Car_pickup_Option/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names")] Car_pickup_Option car_pickup_Option)
        {
            if (ModelState.IsValid)
            {
                db.Car_pickup_Option.Add(car_pickup_Option);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car_pickup_Option);
        }

        // GET: Admin/Car_pickup_Option/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_pickup_Option car_pickup_Option = db.Car_pickup_Option.Find(id);
            if (car_pickup_Option == null)
            {
                return HttpNotFound();
            }
            return View(car_pickup_Option);
        }

        // POST: Admin/Car_pickup_Option/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names")] Car_pickup_Option car_pickup_Option)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car_pickup_Option).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(car_pickup_Option);
        }

        // GET: Admin/Car_pickup_Option/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car_pickup_Option car_pickup_Option = db.Car_pickup_Option.Find(id);
            if (car_pickup_Option == null)
            {
                return HttpNotFound();
            }
            return View(car_pickup_Option);
        }

        // POST: Admin/Car_pickup_Option/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car_pickup_Option car_pickup_Option = db.Car_pickup_Option.Find(id);
            db.Car_pickup_Option.Remove(car_pickup_Option);
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
