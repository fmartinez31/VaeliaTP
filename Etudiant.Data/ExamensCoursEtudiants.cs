//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Etudiant.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ExamensCoursEtudiants
    {
        public int FK_Examens { get; set; }
        public int FK_Cours { get; set; }
        public int FK_Etudiants { get; set; }
        public Nullable<int> Note { get; set; }
    
        public virtual Cours Cours { get; set; }
        public virtual Etudiants Etudiants { get; set; }
        public virtual Examens Examens { get; set; }
    }
}