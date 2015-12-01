using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data.Repositories
{
    public class UtilisateurRepository
    {
        // NE PAS UTILISER LE CONTEXT EN STATIC CAR RISQUE D'ECRASEMENT MULTI-SESSIONS UTILISATEURS
        public void CreateOne(Utilisateurs utilisateur)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Utilisateurs.Add(utilisateur);
            context.SaveChanges();
        }

        public void UpdateOne(Utilisateurs utilisateur)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            Utilisateurs dbUtilisateur = context.Utilisateurs.Find(utilisateur.Id);
            dbUtilisateur.Code = utilisateur.Code;
            dbUtilisateur.MotDePasse = utilisateur.MotDePasse;
            dbUtilisateur.Mail = utilisateur.Mail;
            dbUtilisateur.Profil = utilisateur.Profil;
            dbUtilisateur.Etat = utilisateur.Etat;
            context.SaveChanges();
        }

        public void DeleteOne(int utilisateurId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            context.Utilisateurs.Remove(context.Utilisateurs.Find(utilisateurId));
            context.SaveChanges();
        }

        public Utilisateurs GetOne(int utilisateurId)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Utilisateurs.Find(utilisateurId);
        }

        public bool Verify(string code, string mdp, string etat)
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            List<Utilisateurs> listeutilisateur = context.Utilisateurs.Where(u => (u.Code == code)
                                                                               && (u.MotDePasse == mdp)
                                                                               && (u.Etat == etat)
                                                                            ).ToList();
            return (listeutilisateur != null && listeutilisateur.Count > 0);
        }

        public List<Utilisateurs> GetAll()
        {
            TPDataBaseEntities context = new TPDataBaseEntities();
            return context.Utilisateurs.ToList();
        }
    }
}
