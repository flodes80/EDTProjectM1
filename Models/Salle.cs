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
        [Display(Name = "Nom de la salle")]
        [Required]
        public string NomSalle { get; set;}


        // Bâtiment associé
        [Required]
        public int? BatimentId { get; set; }
        public Batiment Batiment { get; set; }

        // Seances prévues dans la salle
        public ICollection<Seance> Seances { get; set; }

        [Display(Name = "Nom de la salle")]
        public String NomSalleBatiment
        {
            get
            {
                return NomSalle + " - " + ((Batiment != null  && Batiment.NomBatiment != null) ? Batiment.NomBatiment : "");
            }
        }
    }
}
