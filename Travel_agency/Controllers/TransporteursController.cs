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
    public class TransporteursController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Transporteurs
        public ActionResult Index()
        {
            return View(db.Transporteurs.ToList());
        }

        // GET: Transporteurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = db.Transporteurs.Find(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            return View(transporteur);
        }

        // GET: Transporteurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transporteurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroTransporteur,Nom,Type")] Transporteur transporteur)
        {
            if (ModelState.IsValid)
            {
                db.Transporteurs.Add(transporteur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(transporteur);
        }

        // GET: Transporteurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = db.Transporteurs.Find(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            return View(transporteur);
        }

        // POST: Transporteurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroTransporteur,Nom,Type")] Transporteur transporteur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transporteur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transporteur);
        }

        // GET: Transporteurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transporteur transporteur = db.Transporteurs.Find(id);
            if (transporteur == null)
            {
                return HttpNotFound();
            }
            return View(transporteur);
        }

        // POST: Transporteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transporteur transporteur = db.Transporteurs.Find(id);
            db.Transporteurs.Remove(transporteur);
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
