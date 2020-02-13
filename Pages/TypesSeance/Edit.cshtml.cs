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
    public class EditTypesSeance : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public EditTypesSeance(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TypeSeance TypeSeance { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeSeance = await _context.TypesSeance.FirstOrDefaultAsync(m => m.ID == id);

            if (TypeSeance == null)
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

            _context.Attach(TypeSeance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeSeanceExists(TypeSeance.ID))
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

        private bool TypeSeanceExists(int id)
        {
            return _context.TypesSeance.Any(e => e.ID == id);
        }
    }
}
