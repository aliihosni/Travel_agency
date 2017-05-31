using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Travel_agency.Models;

namespace Travel_agency.Controllers
{
    public class DepartsController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Departs
        public ActionResult Index()
        {
            var departs = db.Departs.Include(d => d.Trajet);
            return View(departs.ToList());
        }

        // GET: Departs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // GET: Departs/Create
        public ActionResult Create()
        {
            ViewBag.TrajetId = new SelectList(db.Trajets, "TrajetId", "Depart");
            return View();
        }

        // POST: Departs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartId,DateTime,TrajetId")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Departs.Add(depart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrajetId = new SelectList(db.Trajets, "TrajetId", "Depart", depart.TrajetId);
            return View(depart);
        }

        // GET: Departs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrajetId = new SelectList(db.Trajets, "TrajetId", "Depart", depart.TrajetId);
            return View(depart);
        }

        // POST: Departs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartId,DateTime,TrajetId")] Depart depart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrajetId = new SelectList(db.Trajets, "TrajetId", "Depart", depart.TrajetId);
            return View(depart);
        }

        // GET: Departs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Depart depart = db.Departs.Find(id);
            if (depart == null)
            {
                return HttpNotFound();
            }
            return View(depart);
        }

        // POST: Departs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Depart depart = db.Departs.Find(id);
            db.Departs.Remove(depart);
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
