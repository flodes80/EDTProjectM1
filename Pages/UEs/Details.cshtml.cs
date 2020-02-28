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
    public class DetailsUEs : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public DetailsUEs(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UE UE { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UE = await _context.UE.FirstOrDefaultAsync(m => m.Numero == id);

            if (UE == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
