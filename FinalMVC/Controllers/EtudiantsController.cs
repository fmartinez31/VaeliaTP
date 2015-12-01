using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Etudiant.Data;

namespace FinalMVC.Controllers
{
    public class EtudiantsController : Controller
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // GET: Etudiants
        public ActionResult Index()
        {
            return View(db.Etudiants.ToList());
        }

        // GET: Etudiants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiants etudiants = db.Etudiants.Find(id);
            if (etudiants == null)
            {
                return HttpNotFound();
            }
            return View(etudiants);
        }

        // GET: Etudiants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Etudiants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,DateNaissance,Moyenne,Present,HeureDeRevision,Image")] Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiants);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etudiants);
        }

        // GET: Etudiants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiants etudiants = db.Etudiants.Find(id);
            if (etudiants == null)
            {
                return HttpNotFound();
            }
            return View(etudiants);
        }

        // POST: Etudiants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,DateNaissance,Moyenne,Present,HeureDeRevision,Image")] Etudiants etudiants)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiants).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiants);
        }

        // GET: Etudiants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Etudiants etudiants = db.Etudiants.Find(id);
            if (etudiants == null)
            {
                return HttpNotFound();
            }
            return View(etudiants);
        }

        // POST: Etudiants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiants etudiants = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiants);
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
