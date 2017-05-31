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
    public class SejoursController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Sejours
        public ActionResult Index()
        {
            var sejours = db.Sejours.Include(s => s.Hebergement).Include(s => s.Voyage);
            return View(sejours.ToList());
        }

        // GET: Sejours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // GET: Sejours/Create
        public ActionResult Create()
        {
            ViewBag.HebergementId = new SelectList(db.Hebergements, "HebergementId", "Type");
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage");
            return View();
        }

        // POST: Sejours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SejourId,Type,Description,NumeroVoyage,HebergementId")] Sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.Sejours.Add(sejour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HebergementId = new SelectList(db.Hebergements, "HebergementId", "Type", sejour.HebergementId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", sejour.NumeroVoyage);
            return View(sejour);
        }

        // GET: Sejours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            ViewBag.HebergementId = new SelectList(db.Hebergements, "HebergementId", "Type", sejour.HebergementId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", sejour.NumeroVoyage);
            return View(sejour);
        }

        // POST: Sejours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SejourId,Type,Description,NumeroVoyage,HebergementId")] Sejour sejour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sejour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HebergementId = new SelectList(db.Hebergements, "HebergementId", "Type", sejour.HebergementId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", sejour.NumeroVoyage);
            return View(sejour);
        }

        // GET: Sejours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sejour sejour = db.Sejours.Find(id);
            if (sejour == null)
            {
                return HttpNotFound();
            }
            return View(sejour);
        }

        // POST: Sejours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sejour sejour = db.Sejours.Find(id);
            db.Sejours.Remove(sejour);
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
