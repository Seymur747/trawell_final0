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
    public class Site_settingsController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Site_settings
        public ActionResult Index()
        {
            return View(db.Site_settings.ToList());
        }

        // GET: Admin/Site_settings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_settings site_settings = db.Site_settings.Find(id);
            if (site_settings == null)
            {
                return HttpNotFound();
            }
            return View(site_settings);
        }

        // GET: Admin/Site_settings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Site_settings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,email,numbers,loaction")] Site_settings site_settings)
        {
            if (ModelState.IsValid)
            {
                db.Site_settings.Add(site_settings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(site_settings);
        }

        // GET: Admin/Site_settings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_settings site_settings = db.Site_settings.Find(id);
            if (site_settings == null)
            {
                return HttpNotFound();
            }
            return View(site_settings);
        }

        // POST: Admin/Site_settings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,numbers,loaction")] Site_settings site_settings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(site_settings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(site_settings);
        }

        // GET: Admin/Site_settings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site_settings site_settings = db.Site_settings.Find(id);
            if (site_settings == null)
            {
                return HttpNotFound();
            }
            return View(site_settings);
        }

        // POST: Admin/Site_settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Site_settings site_settings = db.Site_settings.Find(id);
            db.Site_settings.Remove(site_settings);
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
