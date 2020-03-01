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
            CreateViewBags();
            Seances = await _context.Seances
                .Include(s => s.Groupe)
                .Include(s => s.Salle)
                .Include(s => s.Salle.Batiment)
                .Include(s => s.TypeSeance)
                .Include(s => s.UE)
                .ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !IsSeanceValid())
            {
                return Page();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
