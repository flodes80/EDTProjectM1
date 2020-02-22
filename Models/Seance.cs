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
        public int? TypeSeanceId { get; set; }
        public TypeSeance TypeSeance { get; set; }

        // Groupe participant
        public int? GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        // UE appartenance
        [Required]
        public int? UEId { get; set; }
        public UE UE { get; set; }

        // Date de la séance
        [Display(Name = "Date de la séance")]
        [Required]
        public DateTime Date { get; set; }

        // Durée de la séance
        [Display(Name = "Durée séance")]
        [Required]
        public int Duree { get; set; }

    }
}
