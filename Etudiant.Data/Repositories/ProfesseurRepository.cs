using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class ProfesseurRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        public void CreateOne(Professeurs professeur)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Professeurs.Add(professeur);
            context.SaveChanges();
        }

        public void UpdateOne(Professeurs professeur)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Professeurs dbProfesseur = context.Professeurs.Find(professeur.Id);
            dbProfesseur.Nom = professeur.Nom;
            dbProfesseur.Prenom = professeur.Prenom;
            dbProfesseur.Specialite = professeur.Specialite;
            context.SaveChanges();
        }

        public void DeleteOne(int professeurId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Professeurs.Remove(context.Professeurs.Find(professeurId));
            context.SaveChanges();
        }

        public Professeurs GetOne(int professeurId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Professeurs.Find(professeurId);
        }

        public List<Professeurs> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Professeurs.ToList();
        }

        public bool ExistCours(int professeurId, int coursId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Professeurs dbProfesseur = context.Professeurs.Find(professeurId);
            List<Cours> listeCours = dbProfesseur.Cours.ToList();
            if (listeCours != null && listeCours.Count > 0)
            {
                foreach (Cours cours in listeCours)
                {
                    if (cours != null && cours.Id == coursId) return true;
                }
            }
            return false;
        }

        public void AddCours(int professeurId, int coursId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Professeurs dbProfesseur = context.Professeurs.Find(professeurId);
            Cours dbCours = context.Cours.Find(coursId);
            dbProfesseur.Cours.Add(dbCours);
            context.SaveChanges();
        }

        public List<Cours> GetAllCours(int professeurId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Professeurs dbProfesseur = context.Professeurs.Find(professeurId);
            List<Cours> listeCours = dbProfesseur.Cours.ToList();
            return listeCours;
        }
    }
}
