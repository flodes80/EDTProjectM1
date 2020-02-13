using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class Groupe
    {
        // ID Groupe
        public int ID { get; set; }

        // Nom du groupe
        [Required]
        public string NomGroupe { get; set; }

        // UE associée
        [Required]
        public UE UE { get; set; }

        // Séances associées
        public ICollection<Seance> Seances { get; set; }
    }
}
