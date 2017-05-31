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
    public class HebergementsController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Hebergements
        public ActionResult Index()
        {
            return View(db.Hebergements.ToList());
        }

        // GET: Hebergements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hebergement hebergement = db.Hebergements.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            return View(hebergement);
        }

        // GET: Hebergements/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hebergements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HebergementId,Type,Categorie")] Hebergement hebergement)
        {
            if (ModelState.IsValid)
            {
                db.Hebergements.Add(hebergement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hebergement);
        }

        // GET: Hebergements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hebergement hebergement = db.Hebergements.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            return View(hebergement);
        }

        // POST: Hebergements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HebergementId,Type,Categorie")] Hebergement hebergement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hebergement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hebergement);
        }

        // GET: Hebergements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hebergement hebergement = db.Hebergements.Find(id);
            if (hebergement == null)
            {
                return HttpNotFound();
            }
            return View(hebergement);
        }

        // POST: Hebergements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hebergement hebergement = db.Hebergements.Find(id);
            db.Hebergements.Remove(hebergement);
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
