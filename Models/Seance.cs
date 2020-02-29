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
        [Required, DateSeance]
        public DateTime DateDebut { get; set; }

        // Date de fin la séance
        public DateTime DateFin
        {
            get
            {
                return DateDebut.AddHours(Duree);
            }
        }

        // Durée de la séance
        [Display(Name = "Durée séance")]
        [Required, DureeSeance]
        public int Duree { get; set; }

        // Strings pour affichage FullCalendar
        public string StartDateFullCalendarFormat
        {
            get
            {
                return DateDebut.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        public string EndDateFullCalendarFormat
        {
            get
            {
                return DateFin.ToString("yyyy-MM-ddTHH:mm:ss");
            }
        }

        public string TitleFullCalendarFormat
        {
            get
            {
                if (TypeSeance != null && UE != null && Groupe != null && Salle != null)
                    return TypeSeance.Intitule + "\\n" + UE.NomComplet + "\\n" + Groupe.NomGroupe + "\\n" + Salle.NomSalleBatiment;
                else
                    return "Erreur seance";
            }
        }
    }

    internal class DateSeanceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var seance = (Seance) validationContext.ObjectInstance;

            if (seance.DateDebut.DayOfWeek == DayOfWeek.Saturday || seance.DateDebut.DayOfWeek == DayOfWeek.Sunday)
            {
                return new ValidationResult("La séance ne peut avoir lieu qu'en semaine.");
            }

            return ValidationResult.Success;
        }
    }

    internal class DureeSeanceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var seance = (Seance) validationContext.ObjectInstance;

            if (seance.DateFin.Hour > 20)
                return new ValidationResult("La séance ne peut dépasser 20h.");
            else if (seance.Duree <= 0 || seance.Duree > 4)
                return new ValidationResult("La durée d'une séance doit être comprise entre 1h et 4h.");

            return ValidationResult.Success;
        }
    }
}
