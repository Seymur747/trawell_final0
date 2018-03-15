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
    public class EnginesController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Engines
        public ActionResult Index()
        {
            return View(db.Engines.ToList());
        }

        // GET: Admin/Engines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = db.Engines.Find(id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            return View(engine);
        }

        // GET: Admin/Engines/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Engines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,engine_name")] Engine engine)
        {
            if (ModelState.IsValid)
            {
                db.Engines.Add(engine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(engine);
        }

        // GET: Admin/Engines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = db.Engines.Find(id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            return View(engine);
        }

        // POST: Admin/Engines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,engine_name")] Engine engine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(engine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(engine);
        }

        // GET: Admin/Engines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Engine engine = db.Engines.Find(id);
            if (engine == null)
            {
                return HttpNotFound();
            }
            return View(engine);
        }

        // POST: Admin/Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Engine engine = db.Engines.Find(id);
            db.Engines.Remove(engine);
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
