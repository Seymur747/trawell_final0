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
    public class Rent_SuitController : Controller
    {
        private Trawell_DbaseEntities1 db = new Trawell_DbaseEntities1();

        // GET: Admin/Rent_Suit
        public ActionResult Index()
        {
            var rent_Suit = db.Rent_Suit.Include(r => r.Rental).Include(r => r.Suitability);
            return View(rent_Suit.ToList());
        }

        // GET: Admin/Rent_Suit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Suit rent_Suit = db.Rent_Suit.Find(id);
            if (rent_Suit == null)
            {
                return HttpNotFound();
            }
            return View(rent_Suit);
        }

        // GET: Admin/Rent_Suit/Create
        public ActionResult Create()
        {
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title");
            ViewBag.suit_id = new SelectList(db.Suitabilities, "id", "names");
            return View();
        }

        // POST: Admin/Rent_Suit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,rent_id,suit_id")] Rent_Suit rent_Suit)
        {
            if (ModelState.IsValid)
            {
                db.Rent_Suit.Add(rent_Suit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Suit.rent_id);
            ViewBag.suit_id = new SelectList(db.Suitabilities, "id", "names", rent_Suit.suit_id);
            return View(rent_Suit);
        }

        // GET: Admin/Rent_Suit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Suit rent_Suit = db.Rent_Suit.Find(id);
            if (rent_Suit == null)
            {
                return HttpNotFound();
            }
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Suit.rent_id);
            ViewBag.suit_id = new SelectList(db.Suitabilities, "id", "names", rent_Suit.suit_id);
            return View(rent_Suit);
        }

        // POST: Admin/Rent_Suit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,rent_id,suit_id")] Rent_Suit rent_Suit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rent_Suit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.rent_id = new SelectList(db.Rentals, "id", "title", rent_Suit.rent_id);
            ViewBag.suit_id = new SelectList(db.Suitabilities, "id", "names", rent_Suit.suit_id);
            return View(rent_Suit);
        }

        // GET: Admin/Rent_Suit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rent_Suit rent_Suit = db.Rent_Suit.Find(id);
            if (rent_Suit == null)
            {
                return HttpNotFound();
            }
            return View(rent_Suit);
        }

        // POST: Admin/Rent_Suit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rent_Suit rent_Suit = db.Rent_Suit.Find(id);
            db.Rent_Suit.Remove(rent_Suit);
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
