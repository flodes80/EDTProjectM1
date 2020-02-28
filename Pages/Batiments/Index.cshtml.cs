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
    public class IndexBatiment : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexBatiment(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Batiment> Batiment { get;set; }

        public async Task OnGetAsync()
        {
            Batiment = await _context.Batiments.ToListAsync();
        }
    }
}
