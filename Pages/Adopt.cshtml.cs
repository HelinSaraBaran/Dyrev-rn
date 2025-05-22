// Codebehind til Adopter-siden – henter dyr fra service
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;       // For at kunne hente query string
using System.Collections.Generic;
using Domain.Models;
using Service;

namespace Dyreværn.Pages
{
    public class AdoptModel : PageModel
    {
        // Liste med dyr der vises på siden
        public List<Animal> Animals { get; set; } = new List<Animal>();

        // Modtager filter-værdi fra brugerens valg
        [BindProperty(SupportsGet = true)]
        public string Species { get; set; }

        public void OnGet()
        {
            // Opretter instans af service
            AnimalService service = new AnimalService();

            // Henter filtrerede dyr
            Animals = service.FilterBySpecies(Species);
        }
    }
}
