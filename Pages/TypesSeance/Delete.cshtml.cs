using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EDTProjectM1.Data;
using EDTProjectM1.Models;

namespace EDTProjectM1
{
    public class DeleteTypesSeance : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public DeleteTypesSeance(EDTProjectM1.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TypeSeance = await _context.TypesSeance.FindAsync(id);

            if (TypeSeance != null)
            {
                _context.TypesSeance.Remove(TypeSeance);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
