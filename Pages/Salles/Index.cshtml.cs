﻿using System;
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
    public class IndexSalles : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public IndexSalles(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Salle> Salle { get;set; }

        public async Task OnGetAsync()
        {
            Salle = await _context.Salles.Include(s => s.Batiment).ToListAsync();
        }
    }
}
