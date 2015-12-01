using Etudiant.Data.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class EtudiantRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        public void CreateOne(Etudiants etudiant)
        {
            try {
                TPDataBaseEntities context = new TPDataBaseEntities();
                context.Etudiants.Add(etudiant);
                context.SaveChanges();
            }
            catch(Exception e)
            {

            }
        }

        public void UpdateOne(Etudiants etudiant)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Etudiants dbEtudiant = context.Etudiants.Find(etudiant.Id);
            dbEtudiant.Nom = etudiant.Nom;
            dbEtudiant.Prenom = etudiant.Prenom;
            dbEtudiant.DateNaissance = etudiant.DateNaissance;
            dbEtudiant.Moyenne = etudiant.Moyenne;
            dbEtudiant.Present = etudiant.Present;
            context.SaveChanges();
        }

        public void Save()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.SaveChanges();
        }

        public void DeleteOne(int etudiantId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Etudiants.Remove(context.Etudiants.Find(etudiantId));
            context.SaveChanges();
        }

        public Etudiants GetOne(int etudiantId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Etudiants.Find(etudiantId);
        }

        public List<Etudiants> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Etudiants.ToList();
        }

        public bool ExistCours(Etudiants etudiant, Cours cour)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            EtudiantsCours etudiantcours = new EtudiantsCours();
            etudiantcours.Cours = context.Cours.Find(cour.Id);
            etudiantcours.Etudiants = context.Etudiants.Find(etudiant.Id);
                
            // Vérifie si l'association Etudiant/Cours existe déjà
            List<EtudiantsCours> listeetudiantcours = context.EtudiantsCours.Where(ec => 
                                                                                    (ec.FK_Cours == etudiantcours.Cours.Id)
                                                                                &&  (ec.FK_Etudiants == etudiantcours.Etudiants.Id)
                                                                                  ).ToList();
            return (listeetudiantcours != null && listeetudiantcours.Count > 0);
            // OU UTILISATION DU ANY AVEC LINQ => PLUS DIRECT
            //return context.EtudiantsCours.Any(ec => (ec.FK_Cours == etudiantcours.Cour.Id)
            //                                     && (ec.FK_Etudiants == etudiantcours.Etudiant.Id)
            //                                        );
        }

        public void AddCours(Etudiants etudiant, Cours cour)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            EtudiantsCours etudiantcours = new EtudiantsCours();
            etudiantcours.Cours = context.Cours.Find(cour.Id);
            etudiantcours.Etudiants = context.Etudiants.Find(etudiant.Id);

            context.EtudiantsCours.Add(etudiantcours);
            context.SaveChanges();
        }

        public void DeleteCours(int etudiantId, int courId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            List<EtudiantsCours> listeetudiantcours = context.EtudiantsCours.Where(e => (e.FK_Cours == courId) && (e.FK_Etudiants == etudiantId)).ToList();
            context.EtudiantsCours.Remove(listeetudiantcours[0]);
            context.SaveChanges();
        }

        public List<Cours> GetAllCours(int etudiantId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            List<Cours> listeCours = new List<Cours>();
            List<EtudiantsCours> listeetudiantcours = context.EtudiantsCours.Where(e => (e.FK_Etudiants == etudiantId)).ToList();
            if ((listeetudiantcours!=null) && (listeetudiantcours.Count>0))
            {
                foreach (EtudiantsCours _etudiantcours in listeetudiantcours)
                {
                    if (_etudiantcours != null && _etudiantcours.Cours != null) listeCours.Add(_etudiantcours.Cours);
                }
            }
            return listeCours;
        }

        public List<EtudiantsExamens> GetAllExamenDetails(int etudiantId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            List<EtudiantsExamens> liste = new List<EtudiantsExamens>();
            List<ExamensCoursEtudiants> listeexamencoursetudiant = context.ExamensCoursEtudiants.Where(ece => (ece.FK_Etudiants == etudiantId)).ToList();
            if ((listeexamencoursetudiant != null) && (listeexamencoursetudiant.Count > 0))
            {
                EtudiantsExamens etudiantexamen;
                foreach (ExamensCoursEtudiants _examencoursetudiant in listeexamencoursetudiant)
                {
                    if (_examencoursetudiant != null && _examencoursetudiant.Cours != null)
                    {
                        etudiantexamen = new EtudiantsExamens();
                        etudiantexamen.EtudiantNom = _examencoursetudiant.Etudiants.Nom;
                        etudiantexamen.EtudiantPrenom = _examencoursetudiant.Etudiants.Prenom;
                        etudiantexamen.CoursLibelle = _examencoursetudiant.Cours.Libelle;
                        etudiantexamen.ExamenLibelle = _examencoursetudiant.Examens.Libelle;
                        etudiantexamen.ExamenNote = _examencoursetudiant.Note.ToString();
                        liste.Add(etudiantexamen);
                    }
                }
            }
            return liste;
        }
    }
}
