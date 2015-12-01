using Etudiant.Data;
using Etudiant.Data.Entities;
using Etudiant.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Business.Services
{
    public class DataServices
    {
        // SERVICES DE l'ENTITE ETUDIANT
        public static List<Etudiants> GetEtudiants()
        {
            return new EtudiantRepository().GetAll();
        }

        public static void CreateOne(Etudiants etudiant)
        {
            new EtudiantRepository().CreateOne(etudiant);
        }

        public static void UpdateOne(Etudiants etudiant)
        {
            new EtudiantRepository().UpdateOne(etudiant);
        }

        public static void DeleteOne(Etudiants etudiant)
        {
            new EtudiantRepository().DeleteOne(etudiant.Id);
        }

        public static Etudiants GetOne(Etudiants etudiant)
        {
            return new EtudiantRepository().GetOne(etudiant.Id);
        }

        public static bool ExistCours(Etudiants etudiant, Cours cour)
        {
            return new EtudiantRepository().ExistCours(etudiant, cour);
        }

        public static void AddCours(Etudiants etudiant, Cours cour)
        {
            new EtudiantRepository().AddCours(etudiant, cour);
        }

        public static void DeleteCours(Etudiants etudiant, Cours cour)
        {
            new EtudiantRepository().DeleteCours(etudiant.Id, cour.Id);
        }

        public static List<Cours> GetCours(Etudiants etudiant)
        {
            return new EtudiantRepository().GetAllCours(etudiant.Id);
        }

        public static List<EtudiantsExamens> GetExamenDetails(Etudiants etudiant)
        {
            return new EtudiantRepository().GetAllExamenDetails(etudiant.Id);
        }

        // SERVICES DE l'ENTITE PROFESSEUR
        public static void CreateOne(Professeurs professeur)
        {
            new ProfesseurRepository().CreateOne(professeur);
        }

        public static void UpdateOne(Professeurs professeur)
        {
            new ProfesseurRepository().UpdateOne(professeur);
        }

        public static void DeleteOneProfesseur(Professeurs professeur)
        {
            new ProfesseurRepository().DeleteOne(professeur.Id);
        }

        public static Professeurs GetOne(Professeurs professeur)
        {
            return new ProfesseurRepository().GetOne(professeur.Id);
        }

        public static List<Professeurs> GetProfesseurs()
        {
            return new ProfesseurRepository().GetAll();
        }

        public static bool ExistCours(Professeurs professeur, Cours cours)
        {
            return new ProfesseurRepository().ExistCours(professeur.Id, cours.Id);
        }

        public static void AddCours(Professeurs professeur, Cours cours)
        {
            new ProfesseurRepository().AddCours(professeur.Id, cours.Id);
        }

        public static List<Cours> GetCours(Professeurs professeur)
        {
            return new ProfesseurRepository().GetAllCours(professeur.Id);
        }

        // SERVICES DE l'ENTITE UTILISATEUR
        public static void CreateOne(Utilisateurs utilisateur)
        {
            new UtilisateurRepository().CreateOne(utilisateur);
        }

        public static void UpdateOne(Utilisateurs utilisateur)
        {
            new UtilisateurRepository().UpdateOne(utilisateur);
        }

        public static void DeleteOne(Utilisateurs utilisateur)
        {
            new UtilisateurRepository().DeleteOne(utilisateur.Id);
        }

        public static Utilisateurs GetOne(Utilisateurs utilisateur)
        {
            return new UtilisateurRepository().GetOne(utilisateur.Id);
        }

        public static List<Utilisateurs> GetUtilisateurs()
        {
            return new UtilisateurRepository().GetAll();
        }
    }
}
