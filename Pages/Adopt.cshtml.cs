using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;      
using System.Collections.Generic;
using Domain.Models;
using Service;

namespace Dyreværn.Pages
{
    public class AdoptModel : PageModel
    {
        // Liste med dyr der ses på siden
        public List<Animal> Animals { get; set; } = new List<Animal>();

        // Modtager filter værdi fra brugerens valg
        [BindProperty(SupportsGet = true)]
        public string Species { get; set; }

        public void OnGet()
        {
            // Opretter instans af service
            AnimalService service = new AnimalService();

            if (string.IsNullOrEmpty(Species))
            {
                // Hvis ingen art er valgt, vis alle dyr
                Animals = service.GetAllAnimals();
            }
            else
            {
                // Ellers filtrer på valgt art
                Animals = service.FilterBySpecies(Species);
            }
        }

    }
}
