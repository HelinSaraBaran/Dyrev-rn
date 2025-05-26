using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;
using System;

namespace Dyreværn.Pages
{
    // PageModel til detaljeret visning af et dyr og håndtering af besøgslog
    public class AdoptDetailsModel : PageModel
    {
        private AnimalService _service = new AnimalService(); // Service til håndtering af dyr

        public Animal Animal { get; set; } // Det valgte dyr der vises på siden

        // Formularfelter til tilføjelse af besøg
        [BindProperty]
        public DateTime VisitDate { get; set; }     // Dato for besøget

        [BindProperty]
        public string VisitType { get; set; }       // Type af besøg (f.eks. Kunde, Dyrlæge)

        [BindProperty]
        public string VisitNotes { get; set; }      // Noter om besøget

        // Formularfelt til sletning af specifik log-post (index i listen)
        [BindProperty]
        public int IndexToRemove { get; set; }      // Index for besøg der skal fjernes

        // GET – viser dyrets detaljer
        public IActionResult OnGet(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];
                    return Page();
                }
            }

            return NotFound(); // Hvis dyret ikke findes
        }

        // POST – tilføjer en ny besøgslog-post
        public IActionResult OnPost(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];

                    // Opretter ny post og tilføjer den til dyrets besøgslog
                    VisitLogEntry newEntry = new VisitLogEntry
                    {
                        Date = VisitDate,
                        Type = VisitType,
                        Notes = VisitNotes
                    };

                    Animal.VisitLog.Add(newEntry);
                    _service.SaveAnimals(animals);

                    return RedirectToPage(new { id = id }); // Genindlæs siden
                }
            }

            return NotFound();
        }

        // POST – fjerner en specifik besøgslog-post
        public IActionResult OnPostRemoveVisit(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];

                    // Sikrer at index er gyldigt og fjerner posten
                    if (IndexToRemove >= 0 && IndexToRemove < Animal.VisitLog.Count)
                    {
                        Animal.VisitLog.RemoveAt(IndexToRemove);
                        _service.SaveAnimals(animals);
                    }

                    return RedirectToPage(new { id = id }); // Genindlæs siden
                }
            }

            return NotFound();
        }
    }
}
