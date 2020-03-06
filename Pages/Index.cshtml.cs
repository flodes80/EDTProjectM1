using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDTProjectM1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EDTProjectM1.Pages
{
    public class IndexModel : SeanceEditModel
    {
        public IndexModel(EDTProjectM1.Data.ApplicationDbContext context) : base(context)
        {
        }

        public IList<Seance> Seances { get; set; }

        public async Task OnGetAsync()
        {
            // Création des views bags pour modals
            CreateViewBags();

            // Recherche de toutes les séances pour affichage
            Seances = await _context.Seances
                .Include(s => s.Groupe)
                .Include(s => s.Salle)
                .Include(s => s.Salle.Batiment)
                .Include(s => s.TypeSeance)
                .Include(s => s.UE)
                .ToListAsync();
        }

        public async Task<JsonResult> OnGetSeanceByIdAsync(int seanceID)
        {
            Seance = await _context.Seances.FirstOrDefaultAsync(m => m.ID == seanceID);
            return new JsonResult(Seance);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !IsSeanceValid())
            {
                await OnGetAsync();
                @ViewData["ErrorModal"] = true;
                return null;
            }

            // Si création de séance
            if (Seance.ID == 0)
            {
                _context.Seances.Add(Seance);
                await _context.SaveChangesAsync();
            }
            // Sinon mode édition
            else
            {
                var local = _context.Set<Seance>().Local.FirstOrDefault(entry => entry.ID == Seance.ID);
                if (local != null)
                {
                    _context.Entry(local).State = EntityState.Detached;
                }
                _context.Attach(Seance).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeanceExists(Seance.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
