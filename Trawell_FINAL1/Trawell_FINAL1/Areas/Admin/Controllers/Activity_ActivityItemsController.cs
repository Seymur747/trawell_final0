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
    public class Activity_ActivityItemsController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Activity_ActivityItems
        public ActionResult Index()
        {
            var activity_ActivityItems = db.Activity_ActivityItems.Include(a => a.Activity).Include(a => a.Activity_items);
            return View(activity_ActivityItems.ToList());
        }

        // GET: Admin/Activity_ActivityItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_ActivityItems activity_ActivityItems = db.Activity_ActivityItems.Find(id);
            if (activity_ActivityItems == null)
            {
                return HttpNotFound();
            }
            return View(activity_ActivityItems);
        }

        // GET: Admin/Activity_ActivityItems/Create
        public ActionResult Create()
        {
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name");
            ViewBag.activItems_id = new SelectList(db.Activity_items, "id", "items_name");
            return View();
        }

        // POST: Admin/Activity_ActivityItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,activ_id,activItems_id")] Activity_ActivityItems activity_ActivityItems)
        {
            if (ModelState.IsValid)
            {
                db.Activity_ActivityItems.Add(activity_ActivityItems);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_ActivityItems.activ_id);
            ViewBag.activItems_id = new SelectList(db.Activity_items, "id", "items_name", activity_ActivityItems.activItems_id);
            return View(activity_ActivityItems);
        }

        // GET: Admin/Activity_ActivityItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_ActivityItems activity_ActivityItems = db.Activity_ActivityItems.Find(id);
            if (activity_ActivityItems == null)
            {
                return HttpNotFound();
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_ActivityItems.activ_id);
            ViewBag.activItems_id = new SelectList(db.Activity_items, "id", "items_name", activity_ActivityItems.activItems_id);
            return View(activity_ActivityItems);
        }

        // POST: Admin/Activity_ActivityItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,activ_id,activItems_id")] Activity_ActivityItems activity_ActivityItems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_ActivityItems).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_ActivityItems.activ_id);
            ViewBag.activItems_id = new SelectList(db.Activity_items, "id", "items_name", activity_ActivityItems.activItems_id);
            return View(activity_ActivityItems);
        }

        // GET: Admin/Activity_ActivityItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_ActivityItems activity_ActivityItems = db.Activity_ActivityItems.Find(id);
            if (activity_ActivityItems == null)
            {
                return HttpNotFound();
            }
            return View(activity_ActivityItems);
        }

        // POST: Admin/Activity_ActivityItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity_ActivityItems activity_ActivityItems = db.Activity_ActivityItems.Find(id);
            db.Activity_ActivityItems.Remove(activity_ActivityItems);
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
