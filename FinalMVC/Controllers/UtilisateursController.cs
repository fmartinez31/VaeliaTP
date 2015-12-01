using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Etudiant.Data;
using FinalMVC.ViewsModels;
using Etudiant.Data.Repositories;
using SimpleAuthentification;

namespace FinalMVC.Controllers
{
    public class UtilisateursController : Controller
    {
        private TPDataBaseEntities db = new TPDataBaseEntities();
        
        private void initViewBagProfils()
        {
            IList<SelectListItem> liste = new List<SelectListItem>
            {
                new SelectListItem() { Text="A Définir", Value="ADEFINIR"},
                new SelectListItem() { Text="Administrateur", Value="ADMINISTRATEUR"},
                new SelectListItem() { Text="Etudiant", Value="ETUDIANT"},
                new SelectListItem() { Text="Invité", Value="INVITE"},
                new SelectListItem() { Text="Professeur", Value="PROFESSEUR"},
                new SelectListItem() { Text="Valideur", Value="VALIDEUR"},
                new SelectListItem() { Text="Viseur", Value="VISEUR"}
            };
            ViewBag.Profil = new SelectList(liste, "Value", "Text");
        }

        private void initViewBagProfils(string profil)
        {
            IList<SelectListItem> liste = new List<SelectListItem>
            {
                new SelectListItem() { Text="A Définir", Value="ADEFINIR"},
                new SelectListItem() { Text="Administrateur", Value="ADMINISTRATEUR"},
                new SelectListItem() { Text="Etudiant", Value="ETUDIANT"},
                new SelectListItem() { Text="Invité", Value="INVITE"},
                new SelectListItem() { Text="Professeur", Value="PROFESSEUR"},
                new SelectListItem() { Text="Valideur", Value="VALIDEUR"},
                new SelectListItem() { Text="Viseur", Value="VISEUR"}
            };
            ViewBag.Profil = new SelectList(liste, "Value", "Text", profil);
        }

        private void initViewBagEtats()
        {
            IList<SelectListItem> liste = new List<SelectListItem>
            {
                new SelectListItem() { Text="Nouveau", Value="NOUVEAU"},
                new SelectListItem() { Text="Visé", Value="VISE"},
                new SelectListItem() { Text="Validé", Value="VALIDE"}
            };
            ViewBag.Etat = new SelectList(liste, "Value", "Text");
        }

        private void initViewBagEtats(string etat)
        {
            IList<SelectListItem> liste = new List<SelectListItem>
            {
                new SelectListItem() { Text="Nouveau", Value="NOUVEAU"},
                new SelectListItem() { Text="Visé", Value="VISE"},
                new SelectListItem() { Text="Validé", Value="VALIDE"}
            };
            ViewBag.Etat = new SelectList(liste, "Value", "Text", etat);
        }

        private void initViewBagEtudiants()
        {
            List<Etudiants> listeEtudiants = new List<Etudiants>(db.Etudiants);
            Etudiants dbetudiant = new Etudiants();
            dbetudiant.Id = 0;
            dbetudiant.Nom = "Non renseigné";
            listeEtudiants.Insert(0, dbetudiant);
            ViewBag.FK_Etudiants = new SelectList(listeEtudiants, "Id", "Nom");
        }

        private void initViewBagEtudiants(int? etudiantId)
        {
            List<Etudiants> listeEtudiants = new List<Etudiants>(db.Etudiants);
            Etudiants dbetudiant = new Etudiants();
            dbetudiant.Id = 0;
            dbetudiant.Nom = "Non renseigné";
            listeEtudiants.Insert(0, dbetudiant);
            ViewBag.FK_Etudiants = new SelectList(listeEtudiants, "Id", "Nom", etudiantId);
        }

        private void initViewBagProfesseurs()
        {
            List<Professeurs> listeProfesseurs = new List<Professeurs>(db.Professeurs);
            Professeurs dbprofesseur = new Professeurs();
            dbprofesseur.Id = 0;
            dbprofesseur.Nom = "Non renseigné";
            listeProfesseurs.Insert(0, dbprofesseur);
            ViewBag.FK_Professeurs = new SelectList(listeProfesseurs, "Id", "Nom");
        }

        private void initViewBagProfesseurs(int? professeurId)
        {
            List<Professeurs> listeProfesseurs = new List<Professeurs>(db.Professeurs);
            Professeurs dbprofesseur = new Professeurs();
            dbprofesseur.Id = 0;
            dbprofesseur.Nom = "Non renseigné";
            listeProfesseurs.Insert(0, dbprofesseur);
            ViewBag.FK_Professeurs = new SelectList(listeProfesseurs, "Id", "Nom", professeurId);
        }

        [HttpGet]
        public ActionResult CreationCompte()
        {
            ViewBag.Mode = "CREATION_COMPTE";
            Utilisateurs utilisateur = new Utilisateurs();
            utilisateur.Etat = "NOUVEAU";
            utilisateur.Profil = "ADEFINIR";
            ViewBag.FK_Etudiants = new SelectList(new List<Etudiants>());
            ViewBag.FK_Professeurs = new SelectList(new List<Professeurs>());
            return View("Create", utilisateur); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreationCompte([Bind(Include = "Id,Code,MotDePasse,Mail,Profil,Etat,FK_Professeurs,FK_Etudiants")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                ViewBag.Mode = null;
                IdentificationViewModel viewmodel = new IdentificationViewModel();
                return View("Login", viewmodel);
            } else {
                ViewBag.Message = "Erreur de création de compte";
                return RedirectToAction("CreationCompte");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            IdentificationViewModel viewmodel = new IdentificationViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Login(string code, string mdp)
        {
            if (new UtilisateurRepository().Verify(code, mdp, "VALIDE"))
            {
                SessionState.UserName = code;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Message = "Erreur d'authentification : veuillez vérifier l'identifiant et/ou le mot de passe. Si vous n'avez pas encore de compte, utilisez le lien 'Créer un compte'";
            IdentificationViewModel viewmodel = new IdentificationViewModel();
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            IdentificationViewModel viewmodel = new IdentificationViewModel();
            SessionState.UserName = null;
            return RedirectToAction("Login", "Utilisateurs");
        }

        // GET: Utilisateurs
        public ActionResult Index()
        {
            var utilisateurs = db.Utilisateurs.Include(u => u.Etudiants).Include(u => u.Professeurs);
            return View(utilisateurs.ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            initViewBagProfils();
            initViewBagEtats();
            initViewBagEtudiants();
            initViewBagProfesseurs();
            return View();
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,MotDePasse,Mail,Profil,Etat,FK_Professeurs,FK_Etudiants")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                // AJOUT EN BASE DE DONNEES
                if (utilisateurs.FK_Etudiants == 0) utilisateurs.FK_Etudiants = null;
                if (utilisateurs.FK_Professeurs == 0) utilisateurs.FK_Professeurs = null;
                db.Utilisateurs.Add(utilisateurs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            initViewBagProfils(utilisateurs.Profil);
            initViewBagEtats(utilisateurs.Etat);
            initViewBagEtudiants(utilisateurs.FK_Etudiants);
            initViewBagProfesseurs(utilisateurs.FK_Professeurs);
            return View(utilisateurs);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }

            initViewBagProfils(utilisateurs.Profil);
            initViewBagEtats(utilisateurs.Etat);
            initViewBagEtudiants(utilisateurs.FK_Etudiants);
            initViewBagProfesseurs(utilisateurs.FK_Professeurs);

            return View(utilisateurs);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,MotDePasse,Mail,Profil,Etat,FK_Professeurs,FK_Etudiants")] Utilisateurs utilisateurs)
        {
            if (ModelState.IsValid)
            {
                // MODIFICATION EN BASE DE DONNEES
                if (utilisateurs.FK_Etudiants == 0) utilisateurs.FK_Etudiants = null;
                if (utilisateurs.FK_Professeurs == 0) utilisateurs.FK_Professeurs = null;
                db.Entry(utilisateurs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            initViewBagProfils(utilisateurs.Profil);
            initViewBagEtats(utilisateurs.Etat);
            initViewBagEtudiants(utilisateurs.FK_Etudiants);
            initViewBagProfesseurs(utilisateurs.FK_Professeurs);

            return View(utilisateurs);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            if (utilisateurs == null)
            {
                return HttpNotFound();
            }
            return View(utilisateurs);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateurs utilisateurs = db.Utilisateurs.Find(id);
            db.Utilisateurs.Remove(utilisateurs);
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
