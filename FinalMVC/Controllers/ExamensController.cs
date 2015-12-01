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
    public class ExamensController : Controller
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();

        // GET: Examens
        public ActionResult Index()
        {
            return View(db.Examens.ToList());
        }

        // GET: Examens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examens examens = db.Examens.Find(id);
            if (examens == null)
            {
                return HttpNotFound();
            }
            return View(examens);
        }

        // GET: Examens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Examens/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Libelle,Date")] Examens examens)
        {
            if (ModelState.IsValid)
            {
                db.Examens.Add(examens);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(examens);
        }

        // GET: Examens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examens examens = db.Examens.Find(id);
            if (examens == null)
            {
                return HttpNotFound();
            }
            return View(examens);
        }

        // POST: Examens/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Libelle,Date")] Examens examens)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examens).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(examens);
        }

        // GET: Examens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examens examens = db.Examens.Find(id);
            if (examens == null)
            {
                return HttpNotFound();
            }
            return View(examens);
        }

        // POST: Examens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examens examens = db.Examens.Find(id);
            db.Examens.Remove(examens);
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
