using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class CoursRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        public void CreateOne(Cours cours)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Cours.Add(cours);
            context.SaveChanges();
        }

        public void UpdateOne(Cours cours)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Cours dbCours = context.Cours.Find(cours.Id);
            dbCours.Libelle = cours.Libelle;
            context.SaveChanges();
        }

        public void DeleteOne(int coursId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Cours.Remove(context.Cours.Find(coursId));
            context.SaveChanges();
        }

        public Cours GetOne(int coursId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Cours.Find(coursId);
        }

        public List<Cours> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Cours.ToList();
        }

        public List<Etudiants> GetAllEtudiants(int coursId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            List<Etudiants> listeEtudiants = new List<Etudiants>();
            List<EtudiantsCours> listeetudiantcours = context.EtudiantsCours.Where(e => (e.FK_Cours == coursId)).ToList();
            if ((listeetudiantcours != null) && (listeetudiantcours.Count > 0))
            {
                foreach (EtudiantsCours _etudiantcours in listeetudiantcours)
                {
                    if (_etudiantcours != null && _etudiantcours.Cours != null) listeEtudiants.Add(_etudiantcours.Etudiants);
                }
            }
            return listeEtudiants;
        }
    }
}
