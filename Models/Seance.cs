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
        [Required]
        public int? GroupeId { get; set; }
        public Groupe Groupe { get; set; }

        // Salle de la séance
        [Required]
        public int? SalleId { get; set; }
        public Salle Salle { get; set; }

        // UE appartenance
        [Required]
        public int? UEId { get; set; }
        public UE UE { get; set; }

        // Date de la séance
        [Display(Name = "Date de la séance")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        [Required]
        public DateTime Date { get; set; }

        // Durée de la séance
        [Display(Name = "Durée séance")]
        [Range(1, 4, ErrorMessage = "La durée d'une séance doit être comprise entre 1 et 4 heures")]
        [Required]
        public int Duree { get; set; }

        public string StartDateFullCalendarFormat
        {
            get
            {
                return Date.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        public string EndDateFullCalendarFormat
        {
            get
            {
                return Date.AddHours(Duree).ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        public string TitleFullCalendarFormat
        {
            get
            {
                return UE.NomComplet + "\\n" + Groupe.NomGroupe + "\\n" + Salle.NomSalleBatiment;
            }
        }

    }
}
