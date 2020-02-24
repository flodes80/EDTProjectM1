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
    public class CreateSeance : PageModel
    {
        private readonly Data.ApplicationDbContext _context;

        [BindProperty]
        public Seance Seance { get; set; }

        public CreateSeance(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult OnGetGroupeByUE(int ueId)
        {
            return new JsonResult(_context.Set<Groupe>().Where(g => g.UEId == ueId));
        }

        public IActionResult OnGet()
        {
            // Récupération des salles avec les bâtiments associés
            ViewData["Salles"] = new SelectList(_context.Set<Salle>().Include(s => s.Batiment), "ID", "NomSalleBatiment");
            // Récupération des UEs
            ViewData["UEs"] = new SelectList(_context.Set<UE>(), "ID", "NomComplet");
            // Récupération des UEs
            ViewData["TypesSeance"] = new SelectList(_context.Set<TypeSeance>(), "ID", "Intitule");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        /**
         * TODO: Règles ajout séance:
         * 1 groupe ne peut pas deu séance au même moment
         * 1 Séance ne peut avoir lieu dans la même salle au même moment
         **/
    }
}
