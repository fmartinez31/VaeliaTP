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
    public class ProfesseursController : Controller
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // GET: Professeurs
        public ActionResult Index()
        {
            return View(db.Professeurs.ToList());
        }

        // GET: Professeurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeurs professeurs = db.Professeurs.Find(id);
            if (professeurs == null)
            {
                return HttpNotFound();
            }
            return View(professeurs);
        }

        // GET: Professeurs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professeurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,Specialite")] Professeurs professeurs)
        {
            if (ModelState.IsValid)
            {
                db.Professeurs.Add(professeurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professeurs);
        }

        // GET: Professeurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeurs professeurs = db.Professeurs.Find(id);
            if (professeurs == null)
            {
                return HttpNotFound();
            }
            return View(professeurs);
        }

        // POST: Professeurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,Specialite")] Professeurs professeurs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professeurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professeurs);
        }

        // GET: Professeurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professeurs professeurs = db.Professeurs.Find(id);
            if (professeurs == null)
            {
                return HttpNotFound();
            }
            return View(professeurs);
        }

        // POST: Professeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professeurs professeurs = db.Professeurs.Find(id);
            db.Professeurs.Remove(professeurs);
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
