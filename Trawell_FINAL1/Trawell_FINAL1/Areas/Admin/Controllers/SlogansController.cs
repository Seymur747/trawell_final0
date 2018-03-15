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
    public class SlogansController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Slogans
        public ActionResult Index()
        {
            return View(db.Slogans.ToList());
        }

        // GET: Admin/Slogans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slogan slogan = db.Slogans.Find(id);
            if (slogan == null)
            {
                return HttpNotFound();
            }
            return View(slogan);
        }

        // GET: Admin/Slogans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Slogans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,heading,descriptions,logo")] Slogan slogan)
        {
            if (ModelState.IsValid)
            {
                db.Slogans.Add(slogan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slogan);
        }

        // GET: Admin/Slogans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slogan slogan = db.Slogans.Find(id);
            if (slogan == null)
            {
                return HttpNotFound();
            }
            return View(slogan);
        }

        // POST: Admin/Slogans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,heading,descriptions,logo")] Slogan slogan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slogan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slogan);
        }

        // GET: Admin/Slogans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slogan slogan = db.Slogans.Find(id);
            if (slogan == null)
            {
                return HttpNotFound();
            }
            return View(slogan);
        }

        // POST: Admin/Slogans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slogan slogan = db.Slogans.Find(id);
            db.Slogans.Remove(slogan);
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
