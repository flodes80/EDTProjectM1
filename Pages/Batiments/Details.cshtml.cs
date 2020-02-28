using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EDTProjectM1.Data;
using EDTProjectM1.Models;
using Microsoft.AspNetCore.Authorization;

namespace EDTProjectM1
{
    [Authorize(Roles = "Gestionnaire")]
    public class DetailsBatiment : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public DetailsBatiment(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
