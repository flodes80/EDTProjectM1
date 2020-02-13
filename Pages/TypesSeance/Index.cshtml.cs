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
    public class IndexTypesSeance : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public IndexTypesSeance(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<TypeSeance> TypeSeance { get;set; }

        public async Task OnGetAsync()
        {
            TypeSeance = await _context.TypesSeance.ToListAsync();
        }
    }
}
