using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;
using System;

namespace Dyreværn.Pages
{
    // PageModel til detaljeret visning af et dyr og tilføjelse af besøgslog
    public class AdoptDetailsModel : PageModel
    {
        private AnimalService _service = new AnimalService(); // Service til at hente og gemme dyr

        public Animal Animal { get; set; } // Dyret der vises på siden

        // Formularfelter til besøgslog
        [BindProperty]
        public DateTime VisitDate { get; set; }     // Dato for besøget

        [BindProperty]
        public string VisitType { get; set; }       // Type af besøg (f.eks. Kunde, Dyrlæge)

        [BindProperty]
        public string VisitNotes { get; set; }      // Noter om besøget

        public IActionResult OnGet(int id)
        {
            // Henter alle dyr
            List<Animal> animals = _service.GetAllAnimals();

            // Finder det ønskede dyr ud fra ID
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];
                    return Page(); // Viser detaljesiden
                }
            }

            return NotFound(); // Hvis dyret ikke findes
        }

        public IActionResult OnPost(int id)
        {
            // Henter alle dyr
            List<Animal> animals = _service.GetAllAnimals();

            // Finder det ønskede dyr
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];

                    // Opret ny post til besøgsloggen
                    VisitLogEntry newEntry = new VisitLogEntry();
                    newEntry.Date = VisitDate;
                    newEntry.Type = VisitType;
                    newEntry.Notes = VisitNotes;

                    // Tilføj besøget og gem hele listen
                    Animal.VisitLog.Add(newEntry);
                    _service.SaveAnimals(animals);

                    return RedirectToPage(new { id = id }); // Genindlæs siden
                }
            }

            return NotFound(); // Hvis dyret ikke findes
        }
    }
}
