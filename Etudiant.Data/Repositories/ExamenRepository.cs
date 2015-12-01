using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class ExamenRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        public void CreateOne(Examens examen)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Examens.Add(examen);
            context.SaveChanges();
        }

        public void UpdateOne(Examens examen)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Examens dbExamen = context.Examens.Find(examen.Id);
            dbExamen.Libelle = examen.Libelle;
            dbExamen.Date = examen.Date;
            context.SaveChanges();
        }

        public void DeleteOne(int examenId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Examens.Remove(context.Examens.Find(examenId));
            context.SaveChanges();
        }

        public Examens GetOne(int examenId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Examens.Find(examenId);
        }

        public List<Examens> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Examens.ToList();
        }
    }
}
