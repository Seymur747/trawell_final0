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
    public class SuitabilitiesController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Suitabilities
        public ActionResult Index()
        {
            return View(db.Suitabilities.ToList());
        }

        // GET: Admin/Suitabilities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suitability suitability = db.Suitabilities.Find(id);
            if (suitability == null)
            {
                return HttpNotFound();
            }
            return View(suitability);
        }

        // GET: Admin/Suitabilities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Suitabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names,icon")] Suitability suitability)
        {
            if (ModelState.IsValid)
            {
                db.Suitabilities.Add(suitability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suitability);
        }

        // GET: Admin/Suitabilities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suitability suitability = db.Suitabilities.Find(id);
            if (suitability == null)
            {
                return HttpNotFound();
            }
            return View(suitability);
        }

        // POST: Admin/Suitabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names,icon")] Suitability suitability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suitability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suitability);
        }

        // GET: Admin/Suitabilities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suitability suitability = db.Suitabilities.Find(id);
            if (suitability == null)
            {
                return HttpNotFound();
            }
            return View(suitability);
        }

        // POST: Admin/Suitabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suitability suitability = db.Suitabilities.Find(id);
            db.Suitabilities.Remove(suitability);
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
