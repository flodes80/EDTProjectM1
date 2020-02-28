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
    public class IndexSeances : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public IndexSeances(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Seance> Seance { get;set; }

        public async Task OnGetAsync()
        {
            Seance = await _context.Seances
                .Include(s => s.Groupe)
                .Include(s => s.Salle)
                .Include(s => s.Salle.Batiment)
                .Include(s => s.TypeSeance)
                .Include(s => s.UE)
                .ToListAsync();
        }
    }
}
