using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDTProjectM1.Models
{
    public class TypeSeance
    {
        // Clé primaire
        public int ID { get; set; }

        // Intitulé du type de séance.
        // Soit CM, TD ou TP
        [Display(Name = "Type séance")]
        [Required]
        public String Intitule { get; set; }
    }
}
