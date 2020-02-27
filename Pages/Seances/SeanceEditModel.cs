using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDTProjectM1.Models;
using Microsoft.EntityFrameworkCore;

namespace EDTProjectM1
{
    //  Classe Model permettant l'édition d'une séance (création ou modification)
    public class SeanceEditModel : PageModel
    {
        protected readonly Data.ApplicationDbContext _context;

        [BindProperty]
        public Seance Seance { get; set; }
        public string ErrorMessage { get; set; }

        public SeanceEditModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult OnGetGroupeByUE(int ueId)
        {
            return new JsonResult(_context.Set<Groupe>().Where(g => g.UEId == ueId));
        }

        protected void CreateViewBags()
        {
            // Récupération des salles avec les bâtiments associés
            ViewData["Salles"] = new SelectList(_context.Set<Salle>().Include(s => s.Batiment), "ID", "NomSalleBatiment");
            // Récupération des UEs
            ViewData["UEs"] = new SelectList(_context.Set<UE>(), "ID", "NomComplet");
            // Récupération des UEs
            ViewData["TypesSeance"] = new SelectList(_context.Set<TypeSeance>(), "ID", "Intitule");
        }

        protected bool IsSeanceValid()
        {
            /**
             * 1er check:   Existance séance pour le même groupe au même moment
             * 2ème check:  Existance séance dans la même salle au même moment
             * */
             foreach(Seance s in _context.Seances)
            {
                if (s.GroupeId == Seance.GroupeId && ((Seance.DateDebut >= s.DateDebut && Seance.DateDebut < s.DateFin) || (Seance.DateFin > s.DateDebut && Seance.DateFin <= s.DateFin)))
                {
                    ErrorMessage = "Une séance pour un même groupe est déjà prévue à ce créneau horaire";
                    return false;
                }
                else if (s.SalleId == Seance.SalleId && (Seance.DateDebut >= s.DateDebut && Seance.DateDebut < s.DateFin) || (Seance.DateFin > s.DateDebut && Seance.DateFin <= s.DateFin))
                {
                    ErrorMessage = "Une séance dans cette salle est déjà prévue à ce créneau horaire";
                    return false;
                }                  
            }
            ErrorMessage = null;
            return true;
        }
    }
}
