using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class Batiment
    {
        // Clé primaire
        public int ID { get; set; }

        // Nom du bâtiment
        [Required]
        public string NomBatiment { get; set; }

        // Collection des salles du bâtiment
        public ICollection<Salle> Salles { get; set; }
    }
}
