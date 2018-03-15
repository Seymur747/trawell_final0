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
    public class Activity_AttractController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Activity_Attract
        public ActionResult Index()
        {
            var activity_Attract = db.Activity_Attract.Include(a => a.Activity).Include(a => a.Attraction);
            return View(activity_Attract.ToList());
        }

        // GET: Admin/Activity_Attract/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Attract activity_Attract = db.Activity_Attract.Find(id);
            if (activity_Attract == null)
            {
                return HttpNotFound();
            }
            return View(activity_Attract);
        }

        // GET: Admin/Activity_Attract/Create
        public ActionResult Create()
        {
            ViewBag.activity_id = new SelectList(db.Activities, "id", "activ_name");
            ViewBag.attract_id = new SelectList(db.Attractions, "id", "attr_name");
            return View();
        }

        // POST: Admin/Activity_Attract/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,activity_id,attract_id")] Activity_Attract activity_Attract)
        {
            if (ModelState.IsValid)
            {
                db.Activity_Attract.Add(activity_Attract);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activity_id = new SelectList(db.Activities, "id", "activ_name", activity_Attract.activity_id);
            ViewBag.attract_id = new SelectList(db.Attractions, "id", "attr_name", activity_Attract.attract_id);
            return View(activity_Attract);
        }

        // GET: Admin/Activity_Attract/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Attract activity_Attract = db.Activity_Attract.Find(id);
            if (activity_Attract == null)
            {
                return HttpNotFound();
            }
            ViewBag.activity_id = new SelectList(db.Activities, "id", "activ_name", activity_Attract.activity_id);
            ViewBag.attract_id = new SelectList(db.Attractions, "id", "attr_name", activity_Attract.attract_id);
            return View(activity_Attract);
        }

        // POST: Admin/Activity_Attract/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,activity_id,attract_id")] Activity_Attract activity_Attract)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_Attract).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activity_id = new SelectList(db.Activities, "id", "activ_name", activity_Attract.activity_id);
            ViewBag.attract_id = new SelectList(db.Attractions, "id", "attr_name", activity_Attract.attract_id);
            return View(activity_Attract);
        }

        // GET: Admin/Activity_Attract/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Attract activity_Attract = db.Activity_Attract.Find(id);
            if (activity_Attract == null)
            {
                return HttpNotFound();
            }
            return View(activity_Attract);
        }

        // POST: Admin/Activity_Attract/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity_Attract activity_Attract = db.Activity_Attract.Find(id);
            db.Activity_Attract.Remove(activity_Attract);
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
