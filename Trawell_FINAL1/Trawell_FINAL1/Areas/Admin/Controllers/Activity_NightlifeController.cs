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
    public class Activity_NightlifeController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Activity_Nightlife
        public ActionResult Index()
        {
            var activity_Nightlife = db.Activity_Nightlife.Include(a => a.Activity).Include(a => a.Nightlife);
            return View(activity_Nightlife.ToList());
        }

        // GET: Admin/Activity_Nightlife/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Nightlife activity_Nightlife = db.Activity_Nightlife.Find(id);
            if (activity_Nightlife == null)
            {
                return HttpNotFound();
            }
            return View(activity_Nightlife);
        }

        // GET: Admin/Activity_Nightlife/Create
        public ActionResult Create()
        {
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name");
            ViewBag.nightlife_id = new SelectList(db.Nightlives, "id", "night_name");
            return View();
        }

        // POST: Admin/Activity_Nightlife/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,activ_id,nightlife_id")] Activity_Nightlife activity_Nightlife)
        {
            if (ModelState.IsValid)
            {
                db.Activity_Nightlife.Add(activity_Nightlife);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_Nightlife.activ_id);
            ViewBag.nightlife_id = new SelectList(db.Nightlives, "id", "night_name", activity_Nightlife.nightlife_id);
            return View(activity_Nightlife);
        }

        // GET: Admin/Activity_Nightlife/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Nightlife activity_Nightlife = db.Activity_Nightlife.Find(id);
            if (activity_Nightlife == null)
            {
                return HttpNotFound();
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_Nightlife.activ_id);
            ViewBag.nightlife_id = new SelectList(db.Nightlives, "id", "night_name", activity_Nightlife.nightlife_id);
            return View(activity_Nightlife);
        }

        // POST: Admin/Activity_Nightlife/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,activ_id,nightlife_id")] Activity_Nightlife activity_Nightlife)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_Nightlife).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_Nightlife.activ_id);
            ViewBag.nightlife_id = new SelectList(db.Nightlives, "id", "night_name", activity_Nightlife.nightlife_id);
            return View(activity_Nightlife);
        }

        // GET: Admin/Activity_Nightlife/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_Nightlife activity_Nightlife = db.Activity_Nightlife.Find(id);
            if (activity_Nightlife == null)
            {
                return HttpNotFound();
            }
            return View(activity_Nightlife);
        }

        // POST: Admin/Activity_Nightlife/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity_Nightlife activity_Nightlife = db.Activity_Nightlife.Find(id);
            db.Activity_Nightlife.Remove(activity_Nightlife);
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
