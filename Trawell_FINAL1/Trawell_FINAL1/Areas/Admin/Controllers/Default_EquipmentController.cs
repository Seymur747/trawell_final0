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
    public class Default_EquipmentController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Default_Equipment
        public ActionResult Index()
        {
            return View(db.Default_Equipment.ToList());
        }

        // GET: Admin/Default_Equipment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Default_Equipment default_Equipment = db.Default_Equipment.Find(id);
            if (default_Equipment == null)
            {
                return HttpNotFound();
            }
            return View(default_Equipment);
        }

        // GET: Admin/Default_Equipment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Default_Equipment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,def_name,def_icon")] Default_Equipment default_Equipment)
        {
            if (ModelState.IsValid)
            {
                db.Default_Equipment.Add(default_Equipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(default_Equipment);
        }

        // GET: Admin/Default_Equipment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Default_Equipment default_Equipment = db.Default_Equipment.Find(id);
            if (default_Equipment == null)
            {
                return HttpNotFound();
            }
            return View(default_Equipment);
        }

        // POST: Admin/Default_Equipment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,def_name,def_icon")] Default_Equipment default_Equipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(default_Equipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(default_Equipment);
        }

        // GET: Admin/Default_Equipment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Default_Equipment default_Equipment = db.Default_Equipment.Find(id);
            if (default_Equipment == null)
            {
                return HttpNotFound();
            }
            return View(default_Equipment);
        }

        // POST: Admin/Default_Equipment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Default_Equipment default_Equipment = db.Default_Equipment.Find(id);
            db.Default_Equipment.Remove(default_Equipment);
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
