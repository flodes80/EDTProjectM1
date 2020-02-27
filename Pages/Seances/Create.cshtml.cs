using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDTProjectM1.Models;
using Microsoft.EntityFrameworkCore;

namespace EDTProjectM1
{
    public class CreateSeance : SeanceEditModel
    {
        public CreateSeance(Data.ApplicationDbContext context) : base(context)
        {
        }

        public IActionResult OnGet()
        {
            CreateViewBags();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !IsSeanceValid())
            {
                return OnGet();
            }

            _context.Seances.Add(Seance);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
