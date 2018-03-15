using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.Admin.Controllers
{
    public class Activity_photoController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Activity_photo
        public ActionResult Index()
        {
            var activity_photo = db.Activity_photo.Include(a => a.Activity);
            return View(activity_photo.ToList());
        }

        // GET: Admin/Activity_photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_photo activity_photo = db.Activity_photo.Find(id);
            if (activity_photo == null)
            {
                return HttpNotFound();
            }
            return View(activity_photo);
        }

        // GET: Admin/Activity_photo/Create
        public ActionResult Create()
        {
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name");
            return View();
        }

        // POST: Admin/Activity_photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,photo_path,activ_id")] Activity_photo activity_photo,HttpPostedFileBase photo_path)
        {
          
            if (ModelState.IsValid)
            {
                if (photo_path.ContentType != "image/png" && photo_path.ContentType != "image/jpg")
                {
                    Session["Erorr"] = "Incorrect format";

                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + photo_path.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Uploads"), filename);
                photo_path.SaveAs(path);
                activity_photo.photo_path = filename;
                db.Activity_photo.Add(activity_photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_photo.activ_id);
            return View(activity_photo);
        }

        // GET: Admin/Activity_photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_photo activity_photo = db.Activity_photo.Find(id);
            if (activity_photo == null)
            {
                return HttpNotFound();
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_photo.activ_id);
            return View(activity_photo);
        }

        // POST: Admin/Activity_photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,photo_path,activ_id")] Activity_photo activity_photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(activity_photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.activ_id = new SelectList(db.Activities, "id", "activ_name", activity_photo.activ_id);
            return View(activity_photo);
        }

        // GET: Admin/Activity_photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Activity_photo activity_photo = db.Activity_photo.Find(id);
            if (activity_photo == null)
            {
                return HttpNotFound();
            }
            return View(activity_photo);
        }

        // POST: Admin/Activity_photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Activity_photo activity_photo = db.Activity_photo.Find(id);
            db.Activity_photo.Remove(activity_photo);
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
