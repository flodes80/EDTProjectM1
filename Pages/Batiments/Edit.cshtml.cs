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
    public class EditBatiment : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public EditBatiment(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Batiment Batiment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Batiment = await _context.Batiments.FirstOrDefaultAsync(m => m.ID == id);

            if (Batiment == null)
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

            _context.Attach(Batiment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatimentExists(Batiment.ID))
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

        private bool BatimentExists(int id)
        {
            return _context.Batiments.Any(e => e.ID == id);
        }
    }
}
