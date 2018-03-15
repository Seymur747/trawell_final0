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
    public class Admin_InfoController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Admin_Info
        public ActionResult Index()
        {
            return View(db.Admin_Info.ToList());
        }

        // GET: Admin/Admin_Info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Info admin_Info = db.Admin_Info.Find(id);
            if (admin_Info == null)
            {
                return HttpNotFound();
            }
            return View(admin_Info);
        }

        // GET: Admin/Admin_Info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admin_Info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,email,names,passwords")] Admin_Info admin_Info)
        {
            if (ModelState.IsValid)
            {
                db.Admin_Info.Add(admin_Info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin_Info);
        }

        // GET: Admin/Admin_Info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Info admin_Info = db.Admin_Info.Find(id);
            if (admin_Info == null)
            {
                return HttpNotFound();
            }
            return View(admin_Info);
        }

        // POST: Admin/Admin_Info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,names,passwords")] Admin_Info admin_Info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_Info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin_Info);
        }

        // GET: Admin/Admin_Info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_Info admin_Info = db.Admin_Info.Find(id);
            if (admin_Info == null)
            {
                return HttpNotFound();
            }
            return View(admin_Info);
        }

        // POST: Admin/Admin_Info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Admin_Info admin_Info = db.Admin_Info.Find(id);
            db.Admin_Info.Remove(admin_Info);
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
