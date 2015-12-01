using Etudiant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalMVC.ViewsModels
{
    public class IdentificationViewModel
    {
        public Utilisateurs Utilisateur { get; set; }

        public IdentificationViewModel()
        {
            Utilisateur = new Utilisateurs();
        }
    }
}