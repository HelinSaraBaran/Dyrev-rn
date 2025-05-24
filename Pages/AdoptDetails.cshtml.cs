using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;
using System;

namespace Dyreværn.Pages
{
    public class AdoptDetailsModel : PageModel
    {
        private AnimalService _service = new AnimalService();

        public Animal Animal { get; set; }

        // Bind properties til besøgslog
        [BindProperty]
        public DateTime VisitDate { get; set; }

        [BindProperty]
        public string VisitType { get; set; }

        [BindProperty]
        public string VisitNotes { get; set; }

        // GET – vis detaljer for dyret
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

            return NotFound();
        }

        // POST – tilføj besøg
        public IActionResult OnPost(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];

                    // Opret ny besøgslogpost
                    VisitLogEntry newEntry = new VisitLogEntry();
                    newEntry.Date = VisitDate;
                    newEntry.Type = VisitType;
                    newEntry.Notes = VisitNotes;

                    Animal.VisitLog.Add(newEntry);
                    _service.SaveAnimals(animals);

                    return RedirectToPage(new { id = id });
                }
            }

            return NotFound();
        }
    }
}
