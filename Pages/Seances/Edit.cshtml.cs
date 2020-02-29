using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDTProjectM1.Data;
using EDTProjectM1.Models;
using Microsoft.AspNetCore.Authorization;

namespace EDTProjectM1
{
    [Authorize(Roles = "Gestionnaire")]
    public class EditSeance : SeanceEditModel
    {
        public EditSeance(EDTProjectM1.Data.ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Seance = await _context.Seances.FirstOrDefaultAsync(m => m.ID == id);

            if (Seance == null)
            {
                return NotFound();
            }

            // Chargement des ViewBags (UE, Salles etc ..)
            CreateViewBags();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !IsSeanceValid())
            {
                if (Seance != null)
                    return await OnGetAsync(Seance.ID);
                else
                    return Page();
            }

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

            return RedirectToPage("./Index");
        }

        private bool SeanceExists(int id)
        {
            return _context.Seances.Any(e => e.ID == id);
        }
    }
}
