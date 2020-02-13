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
        [Key]
        public int Numero { get; set; }

        // Intitulé de l'UE
        [Required]
        public string Intitule { get; set; }

        // Seances associées
        public ICollection<Seance> Seances { get; set; }
    }
}
