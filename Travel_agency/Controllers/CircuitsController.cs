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
    public class CircuitsController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Circuits
        public ActionResult Index()
        {
            var circuits = db.Circuits.Include(c => c.Parcours).Include(c => c.Voyage);
            return View(circuits.ToList());
        }

        // GET: Circuits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            return View(circuit);
        }

        // GET: Circuits/Create
        public ActionResult Create()
        {
            ViewBag.ParcoursId = new SelectList(db.Parcours, "ParcoursId", "ParcoursId");
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage");
            return View();
        }

        // POST: Circuits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CircuitId,Theme,Description,MoyenTransport,NumeroVoyage,ParcoursId")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                db.Circuits.Add(circuit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ParcoursId = new SelectList(db.Parcours, "ParcoursId", "ParcoursId", circuit.ParcoursId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", circuit.NumeroVoyage);
            return View(circuit);
        }

        // GET: Circuits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParcoursId = new SelectList(db.Parcours, "ParcoursId", "ParcoursId", circuit.ParcoursId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", circuit.NumeroVoyage);
            return View(circuit);
        }

        // POST: Circuits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CircuitId,Theme,Description,MoyenTransport,NumeroVoyage,ParcoursId")] Circuit circuit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(circuit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ParcoursId = new SelectList(db.Parcours, "ParcoursId", "ParcoursId", circuit.ParcoursId);
            ViewBag.NumeroVoyage = new SelectList(db.Voyages, "NumeroVoyage", "NumeroVoyage", circuit.NumeroVoyage);
            return View(circuit);
        }

        // GET: Circuits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Circuit circuit = db.Circuits.Find(id);
            if (circuit == null)
            {
                return HttpNotFound();
            }
            return View(circuit);
        }

        // POST: Circuits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Circuit circuit = db.Circuits.Find(id);
            db.Circuits.Remove(circuit);
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
