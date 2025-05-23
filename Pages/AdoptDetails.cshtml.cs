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
        // Service der henter og gemmer dyredata
        private AnimalService _service = new AnimalService();

        // Det valgte dyr vises på siden
        public Animal Animal { get; set; }

        // Egenskaber til at oprette ny besøgslogpost
        [BindProperty]
        public DateTime VisitDate { get; set; } // Dato for besøget

        [BindProperty]
        public string VisitType { get; set; }   // Type: fx dyrlæge eller kunde

        [BindProperty]
        public string VisitDescription { get; set; } // Beskrivelse af besøget

        // Kører når siden åbnes med et id
        public IActionResult OnGet(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            // Finder dyret ud fra id
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];
                    return Page(); // Vis siden
                }
            }

            return NotFound(); // Hvis intet dyr findes
        }

        // Kører når man tilføjer et besøg
        public IActionResult OnPost(int id)
        {
            List<Animal> animals = _service.GetAllAnimals();

            // Finder dyret igen
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].Id == id)
                {
                    Animal = animals[i];

                    // Opret ny besøgslogpost
                    VisitLogEntry newEntry = new VisitLogEntry();
                    newEntry.Date = VisitDate;
                    newEntry.Type = VisitType;
                    newEntry.Description = VisitDescription;

                    // Tilføjer til dyrets log og gemmer
                    Animal.VisitLog.Add(newEntry);
                    _service.SaveAnimals(animals);

                    return RedirectToPage(new { id = id }); // Genindlæs siden
                }
            }

            return NotFound();
        }
    }
}
