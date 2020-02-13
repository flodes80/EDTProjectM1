using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class Seance
    {
        // Clé primaire
        public int ID { get; set; }

        // Type de séance
        [Required]
        public TypeSeance TypeSeance { get; set; }

        // Groupe participant
        public Groupe Groupe { get; set; }

        // UE appartenance
        [Required]
        public UE UE { get; set; }

        // Date de la séance
        [Required]
        public DateTime Date { get; set; }
        
        // Durée de la séance
        [Required]
        public int Duree { get; set; }

    }
}
