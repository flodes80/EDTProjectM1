using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class UE
    {
        // Clé primaire
        public int ID { get; set; }

        // Numéro de l'UE
        [Display(Name = "Numéro de l'UE")]
        [Required]
        public int Numero { get; set; }

        // Intitulé de l'UE
        [Display(Name = "Intitulé de l'UE")]
        [Required]
        public string Intitule { get; set; }

        // Seances associées
        public ICollection<Seance> Seances { get; set; }
    }
}
