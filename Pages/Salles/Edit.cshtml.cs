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

namespace EDTProjectM1
{
    public class EditSalle : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public EditSalle(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Salle Salle { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            ViewData["Batiments"] = new SelectList(_context.Set<Batiment>(), "ID", "NomBatiment");

            if (id == null)
            {
                return NotFound();
            }

            Salle = await _context.Salles.Include(s => s.Batiment).FirstOrDefaultAsync(m => m.ID == id);

            if (Salle == null)
            {
                return NotFound();
            }
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

            _context.Attach(Salle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalleExists(Salle.ID))
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

        private bool SalleExists(int id)
        {
            return _context.Salles.Any(e => e.ID == id);
        }
    }
}
