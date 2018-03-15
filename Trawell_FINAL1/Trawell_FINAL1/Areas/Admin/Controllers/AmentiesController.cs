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
    public class AmentiesController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Amenties
        public ActionResult Index()
        {
            return View(db.Amenties.ToList());
        }

        // GET: Admin/Amenties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenty amenty = db.Amenties.Find(id);
            if (amenty == null)
            {
                return HttpNotFound();
            }
            return View(amenty);
        }

        // GET: Admin/Amenties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Amenties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,names,icon")] Amenty amenty)
        {
            if (ModelState.IsValid)
            {
                db.Amenties.Add(amenty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(amenty);
        }

        // GET: Admin/Amenties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenty amenty = db.Amenties.Find(id);
            if (amenty == null)
            {
                return HttpNotFound();
            }
            return View(amenty);
        }

        // POST: Admin/Amenties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,names,icon")] Amenty amenty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(amenty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(amenty);
        }

        // GET: Admin/Amenties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Amenty amenty = db.Amenties.Find(id);
            if (amenty == null)
            {
                return HttpNotFound();
            }
            return View(amenty);
        }

        // POST: Admin/Amenties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Amenty amenty = db.Amenties.Find(id);
            db.Amenties.Remove(amenty);
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
