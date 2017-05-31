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
    public class AccompagnateursController : Controller
    {
        private Travel_agencyContext db = new Travel_agencyContext();

        // GET: Accompagnateurs
        public ActionResult Index()
        {
            return View(db.Accompagnateurs.ToList());
        }

        // GET: Accompagnateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accompagnateur accompagnateur = db.Accompagnateurs.Find(id);
            if (accompagnateur == null)
            {
                return HttpNotFound();
            }
            return View(accompagnateur);
        }

        // GET: Accompagnateurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accompagnateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumeroAccompagnateur,Nom,Prenom,Adresse")] Accompagnateur accompagnateur)
        {
            if (ModelState.IsValid)
            {
                db.Accompagnateurs.Add(accompagnateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(accompagnateur);
        }

        // GET: Accompagnateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accompagnateur accompagnateur = db.Accompagnateurs.Find(id);
            if (accompagnateur == null)
            {
                return HttpNotFound();
            }
            return View(accompagnateur);
        }

        // POST: Accompagnateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumeroAccompagnateur,Nom,Prenom,Adresse")] Accompagnateur accompagnateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accompagnateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accompagnateur);
        }

        // GET: Accompagnateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accompagnateur accompagnateur = db.Accompagnateurs.Find(id);
            if (accompagnateur == null)
            {
                return HttpNotFound();
            }
            return View(accompagnateur);
        }

        // POST: Accompagnateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accompagnateur accompagnateur = db.Accompagnateurs.Find(id);
            db.Accompagnateurs.Remove(accompagnateur);
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
