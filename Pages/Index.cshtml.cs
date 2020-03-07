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
            // Si erreur on réaffiche les données de la séance qui était en cours d'édition
            if(TempData["ErrorMessage"] != null && TempData["ErrorInModal"] != null)
            {
                LoadModelError();
            }

            // Création des views bags pour modals
            CreateViewBags();

            // Recherche de toutes les séances pour affichage
            Seances = await _context.Seances
                .Include(s => s.Groupe)
                .Include(s => s.Salle)
                .Include(s => s.Salle.Batiment)
                .Include(s => s.TypeSeance)
                .Include(s => s.UE)
                .ToListAsync();
        }

        public async Task<JsonResult> OnGetSeanceByIdAsync(int seanceID)
        {
            Seance = await _context.Seances.FirstOrDefaultAsync(m => m.ID == seanceID);
            return new JsonResult(Seance);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || !IsSeanceValid())
            {
                if ((string)ViewData["Title"] == "Consult")
                {
                    SaveModelError();
                }
                
            }
            else
            {
                // Si création de séance
                if (Seance.ID == 0)
                {
                    _context.Seances.Add(Seance);
                    await _context.SaveChangesAsync();
                }
                // Sinon mode édition
                else
                {
                    var local = _context.Set<Seance>().Local.FirstOrDefault(entry => entry.ID == Seance.ID);
                    if (local != null)
                    {
                        _context.Entry(local).State = EntityState.Detached;
                    }
                    _context.Attach(Seance).State = EntityState.Modified;

                    try
                    {
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!SeanceExists(Seance.ID))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return RedirectToPage("./Index");
        }
        
        // Sauvegarde du model en erreur dans modal
        private void SaveModelError()
        {
            TempData["ErrorModelDateDebut"] = Seance.DateDebut;
            TempData["ErrorModelDuree"] = Seance.Duree;
            TempData["ErrorModelGroupeId"] = Seance.GroupeId;
            TempData["ErrorModelSalleId"] = Seance.SalleId;
            TempData["ErrorModelUEId"] = Seance.UEId;
            TempData["ErrorModelTypeSeanceId"] = Seance.TypeSeanceId;
            TempData["ErrorInModal"] = true;
        }

        // Chargement du modèle en erreur dans modal
        private void LoadModelError()
        {
            // Création et remplissage du modèle en erreur
            Seance = new Seance();
            Seance.DateDebut = (DateTime)TempData["ErrorModelDateDebut"];
            Seance.Duree = (int)TempData["ErrorModelDuree"];
            Seance.GroupeId = (int)TempData["ErrorModelGroupeId"];
            Seance.SalleId = (int)TempData["ErrorModelSalleId"];
            Seance.UEId = (int)TempData["ErrorModelUEId"];
            Seance.TypeSeanceId = (int)TempData["ErrorModelTypeSeanceId"];

            // Suppression du cache du modèle en erreur
            TempData.Remove("ErrorModelDateDebut");
            TempData.Remove("ErrorModelDuree");
            TempData.Remove("ErrorModelGroupeId");
            TempData.Remove("ErrorModelSalleId");
            TempData.Remove("ErrorModelUEId");
            TempData.Remove("ErrorModelTypeSeanceId");
            TempData.Remove("ErrorInModal");
            TempData.Remove("ErrorInModal");
        }
    }
}
