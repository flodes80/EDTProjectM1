﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDTProjectM1.Data;
using EDTProjectM1.Models;
using Microsoft.AspNetCore.Authorization;

namespace EDTProjectM1
{
    [Authorize(Roles = "Gestionnaire")]
    public class CreateGroupe : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public CreateGroupe(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["UEs"] = new SelectList(_context.Set<UE>(), "ID", "NomComplet");
            return Page();
        }

        [BindProperty]
        public Groupe Groupe { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Groupes.Add(Groupe);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
