using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trawell_FINAL1.Models;

namespace Trawell_FINAL1.Areas.Admin.Controllers
{
    public class CarsController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();
        // GET: Admin/Cars
        public ActionResult Index()
        {
            var cars = db.Cars.Include(c => c.Car_pickup_Option).Include(c => c.Cars_group).Include(c => c.Cars_trans).Include(c => c.Engine);
            return View(cars.ToList());
        }

        // GET: Admin/Cars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Admin/Cars/Create
        public ActionResult Create()
        {
            ViewBag.car_pickup_id = new SelectList(db.Car_pickup_Option, "id", "names");
            ViewBag.car_grop_id = new SelectList(db.Cars_group, "id", "group_name");
            ViewBag.car_trans_id = new SelectList(db.Cars_trans, "id", "trans_name");
            ViewBag.car_engine_id = new SelectList(db.Engines, "id", "engine_name");
            return View();
        }

        // POST: Admin/Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,car_Name,car_Price,car_Location,owner_Email,owner_Number,car_PickUpTime,car_DropOffTime,car_PickUpPlace,car_DropOffPlace,car_Description,car_grop_id,car_pickup_id,car_trans_id,car_engine_id,passabgers_num,car_door_num,car_baggage_quantity,car_photo")] Car car, HttpPostedFileBase car_photo)
        {
            if (ModelState.IsValid)
            {
                if (car_photo.ContentType != "image/png" && car_photo.ContentType != "image/jpg")
                {
                    Session["Erorr"] = "Incorrect format";

                }
                string filename = DateTime.Now.ToString("ddMMyyyyHHmmssffff") + car_photo.FileName;
                string path = Path.Combine(Server.MapPath("~/Areas/Admin/Uploads"), filename);
                car_photo.SaveAs(path);
                car.car_photo = filename;
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.car_pickup_id = new SelectList(db.Car_pickup_Option, "id", "names", car.car_pickup_id);
            ViewBag.car_grop_id = new SelectList(db.Cars_group, "id", "group_name", car.car_grop_id);
            ViewBag.car_trans_id = new SelectList(db.Cars_trans, "id", "trans_name", car.car_trans_id);
            ViewBag.car_engine_id = new SelectList(db.Engines, "id", "engine_name", car.car_engine_id);
            return View(car);
        }

        // GET: Admin/Cars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.car_pickup_id = new SelectList(db.Car_pickup_Option, "id", "names", car.car_pickup_id);
            ViewBag.car_grop_id = new SelectList(db.Cars_group, "id", "group_name", car.car_grop_id);
            ViewBag.car_trans_id = new SelectList(db.Cars_trans, "id", "trans_name", car.car_trans_id);
            ViewBag.car_engine_id = new SelectList(db.Engines, "id", "engine_name", car.car_engine_id);
            return View(car);
        }

        // POST: Admin/Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,car_Name,car_Price,car_Location,owner_Email,owner_Number,car_PickUpTime,car_DropOffTime,car_PickUpPlace,car_DropOffPlace,car_Description,car_grop_id,car_pickup_id,car_trans_id,car_engine_id,passabgers_num,car_door_num,car_baggage_quantity,car_photo")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.car_pickup_id = new SelectList(db.Car_pickup_Option, "id", "names", car.car_pickup_id);
            ViewBag.car_grop_id = new SelectList(db.Cars_group, "id", "group_name", car.car_grop_id);
            ViewBag.car_trans_id = new SelectList(db.Cars_trans, "id", "trans_name", car.car_trans_id);
            ViewBag.car_engine_id = new SelectList(db.Engines, "id", "engine_name", car.car_engine_id);
            return View(car);
        }

        // GET: Admin/Cars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Admin/Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = db.Cars.Find(id);
            db.Cars.Remove(car);
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
