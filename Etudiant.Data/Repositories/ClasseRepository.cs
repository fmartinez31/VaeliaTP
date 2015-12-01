using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class ClasseRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        //static TPDataBaseEntities context = new TPDataBaseEntities();

        public void CreateOne(Classes classe)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Classes.Add(classe);
            context.SaveChanges();
        }

        public void UpdateOne(Classes classe)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Classes dbClasse = context.Classes.Find(classe.Id);
            dbClasse.Libelle = classe.Libelle;
            dbClasse.Annee = classe.Annee;
            context.SaveChanges();
        }

        public void DeleteOne(int classeId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Classes.Remove(context.Classes.Find(classeId));
            context.SaveChanges();
        }

        public Classes GetOne(int classeId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Classes.Find(classeId);
        }

        public List<Classes> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Classes.ToList();
        }
    }
}
