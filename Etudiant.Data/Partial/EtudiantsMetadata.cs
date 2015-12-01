using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data
{
    public class EtudiantsMetadata
    {
        // Data Annotations
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yy}")]
        public Nullable<System.DateTime> DateNaissance { get; set; }

    }
}
