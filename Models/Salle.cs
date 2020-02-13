using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class Salle
    {
        // Clé primaire
        public int ID { get; set; }
        
        // Nom de la salle
        [Required]
        public string NomSalle { get; set;}

        // Bâtiment associé
        [Required]
        public Batiment Batiment { get; set; }

        // Seances prévues dans la salle
        public ICollection<Seance> Seances { get; set; }
    }
}
