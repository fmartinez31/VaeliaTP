using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etudiant.Data
{
    // Fixe les Metadata des propriétés redéfinies dans EtudiantsMetadata
    [MetadataType(typeof(EtudiantsMetadata))]
    public partial class Etudiants
    {
        // public byte[] Image { get; set; }        
    }
}
