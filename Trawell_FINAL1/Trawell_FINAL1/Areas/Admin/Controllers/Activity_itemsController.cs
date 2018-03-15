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
    public class Activity_itemsController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Activity_items
        public ActionResult Index()
        {
            return View(db.Activity_items.ToList());
        }

        // GET: Admin/Activity_items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_items activity_items = db.Activity_items.Find(id);
            if (activity_items == null)
            {
                return HttpNotFound();
            }
            return View(activity_items);
        }

        // GET: Admin/Activity_items/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Activity_items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,items_name")] Activity_items activity_items)
        {
            if (ModelState.IsValid)
            {
                db.Activity_items.Add(activity_items);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(activity_items);
        }

        // GET: Admin/Activity_items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_items activity_items = db.Activity_items.Find(id);
            if (activity_items == null)
            {
                return HttpNotFound();
            }
            return View(activity_items);
        }

        // POST: Admin/Activity_items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,items_name")] Activity_items activity_items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_items).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(activity_items);
        }

        // GET: Admin/Activity_items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_items activity_items = db.Activity_items.Find(id);
            if (activity_items == null)
            {
                return HttpNotFound();
            }
            return View(activity_items);
        }

        // POST: Admin/Activity_items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity_items activity_items = db.Activity_items.Find(id);
            db.Activity_items.Remove(activity_items);
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
