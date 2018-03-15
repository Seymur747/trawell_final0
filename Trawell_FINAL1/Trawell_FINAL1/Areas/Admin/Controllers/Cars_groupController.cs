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
    public class Cars_groupController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();
        // GET: Admin/Cars_group
        public ActionResult Index()
        {
            return View(db.Cars_group.ToList());
        }

        // GET: Admin/Cars_group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_group cars_group = db.Cars_group.Find(id);
            if (cars_group == null)
            {
                return HttpNotFound();
            }
            return View(cars_group);
        }

        // GET: Admin/Cars_group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cars_group/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,group_name")] Cars_group cars_group)
        {
            if (ModelState.IsValid)
            {
                db.Cars_group.Add(cars_group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cars_group);
        }

        // GET: Admin/Cars_group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_group cars_group = db.Cars_group.Find(id);
            if (cars_group == null)
            {
                return HttpNotFound();
            }
            return View(cars_group);
        }

        // POST: Admin/Cars_group/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,group_name")] Cars_group cars_group)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cars_group).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cars_group);
        }

        // GET: Admin/Cars_group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cars_group cars_group = db.Cars_group.Find(id);
            if (cars_group == null)
            {
                return HttpNotFound();
            }
            return View(cars_group);
        }

        // POST: Admin/Cars_group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cars_group cars_group = db.Cars_group.Find(id);
            db.Cars_group.Remove(cars_group);
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
