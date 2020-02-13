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
    public class DetailsGroupe : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public DetailsGroupe(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Groupe Groupe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Groupe = await _context.Groupes.FirstOrDefaultAsync(m => m.ID == id);

            if (Groupe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
