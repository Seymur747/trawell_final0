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
    public class NightlivesController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Nightlives
        public ActionResult Index()
        {
            return View(db.Nightlives.ToList());
        }

        // GET: Admin/Nightlives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightlife nightlife = db.Nightlives.Find(id);
            if (nightlife == null)
            {
                return HttpNotFound();
            }
            return View(nightlife);
        }

        // GET: Admin/Nightlives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nightlives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,night_name")] Nightlife nightlife)
        {
            if (ModelState.IsValid)
            {
                db.Nightlives.Add(nightlife);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nightlife);
        }

        // GET: Admin/Nightlives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightlife nightlife = db.Nightlives.Find(id);
            if (nightlife == null)
            {
                return HttpNotFound();
            }
            return View(nightlife);
        }

        // POST: Admin/Nightlives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,night_name")] Nightlife nightlife)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nightlife).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nightlife);
        }

        // GET: Admin/Nightlives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nightlife nightlife = db.Nightlives.Find(id);
            if (nightlife == null)
            {
                return HttpNotFound();
            }
            return View(nightlife);
        }

        // POST: Admin/Nightlives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nightlife nightlife = db.Nightlives.Find(id);
            db.Nightlives.Remove(nightlife);
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
