using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        // Données calculées non persistante
        [Display(Name = "Nom de l'UE")]
        public string NomComplet
        {
            get
            {
                return Numero + " - " + Intitule;
            }
        }

        // Seances associées
        public ICollection<Seance> Seances { get; set; }
    }
}
