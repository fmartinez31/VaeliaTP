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
    
    public partial class Examens
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Examens()
        {
            this.ExamensCoursEtudiants = new HashSet<ExamensCoursEtudiants>();
        }
    
        public int Id { get; set; }
        public string Libelle { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExamensCoursEtudiants> ExamensCoursEtudiants { get; set; }
    }
}
