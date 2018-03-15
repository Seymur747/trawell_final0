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
    public class PickUp_FeaturesController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/PickUp_Features
        public ActionResult Index()
        {
            return View(db.PickUp_Features.ToList());
        }

        // GET: Admin/PickUp_Features/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp_Features pickUp_Features = db.PickUp_Features.Find(id);
            if (pickUp_Features == null)
            {
                return HttpNotFound();
            }
            return View(pickUp_Features);
        }

        // GET: Admin/PickUp_Features/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PickUp_Features/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pickup_name,pickup_icon")] PickUp_Features pickUp_Features)
        {
            if (ModelState.IsValid)
            {
                db.PickUp_Features.Add(pickUp_Features);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pickUp_Features);
        }

        // GET: Admin/PickUp_Features/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp_Features pickUp_Features = db.PickUp_Features.Find(id);
            if (pickUp_Features == null)
            {
                return HttpNotFound();
            }
            return View(pickUp_Features);
        }

        // POST: Admin/PickUp_Features/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pickup_name,pickup_icon")] PickUp_Features pickUp_Features)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pickUp_Features).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pickUp_Features);
        }

        // GET: Admin/PickUp_Features/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PickUp_Features pickUp_Features = db.PickUp_Features.Find(id);
            if (pickUp_Features == null)
            {
                return HttpNotFound();
            }
            return View(pickUp_Features);
        }

        // POST: Admin/PickUp_Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PickUp_Features pickUp_Features = db.PickUp_Features.Find(id);
            db.PickUp_Features.Remove(pickUp_Features);
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
