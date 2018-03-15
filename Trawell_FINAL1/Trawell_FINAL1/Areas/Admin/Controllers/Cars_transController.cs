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
    public class Cars_transController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Cars_trans
        public ActionResult Index()
        {
            return View(db.Cars_trans.ToList());
        }

        // GET: Admin/Cars_trans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_trans cars_trans = db.Cars_trans.Find(id);
            if (cars_trans == null)
            {
                return HttpNotFound();
            }
            return View(cars_trans);
        }

        // GET: Admin/Cars_trans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cars_trans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,trans_name")] Cars_trans cars_trans)
        {
            if (ModelState.IsValid)
            {
                db.Cars_trans.Add(cars_trans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars_trans);
        }

        // GET: Admin/Cars_trans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_trans cars_trans = db.Cars_trans.Find(id);
            if (cars_trans == null)
            {
                return HttpNotFound();
            }
            return View(cars_trans);
        }

        // POST: Admin/Cars_trans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,trans_name")] Cars_trans cars_trans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_trans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars_trans);
        }

        // GET: Admin/Cars_trans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_trans cars_trans = db.Cars_trans.Find(id);
            if (cars_trans == null)
            {
                return HttpNotFound();
            }
            return View(cars_trans);
        }

        // POST: Admin/Cars_trans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_trans cars_trans = db.Cars_trans.Find(id);
            db.Cars_trans.Remove(cars_trans);
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
