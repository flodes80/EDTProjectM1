using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EDTProjectM1.Data;
using EDTProjectM1.Models;

namespace EDTProjectM1
{
    public class CreateSalle : PageModel
    {
        private readonly EDTProjectM1.Data.ApplicationDbContext _context;

        public CreateSalle(EDTProjectM1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Salle Salle { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Salles.Add(Salle);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
