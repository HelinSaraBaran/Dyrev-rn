using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;

namespace Dyreværn.Pages
{
    // PageModel til oprettelse af et nyt dyr i systemet
    public class CreateAnimalModel : PageModel
    {
        [BindProperty]
        public Animal Animal { get; set; } // Formularbinding til dyret der oprettes

        private AnimalService _animalService;

        // Constructor – initialiserer service
        public CreateAnimalModel()
        {
            _animalService = new AnimalService();
        }

        public void OnGet()
        {
            Animal = new Animal(); // Opretter tomt dyr-objekt til formularen
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Vis siden igen hvis der er valideringsfejl
            }

            // Tilføjer dyret via service
            _animalService.AddAnimal(Animal);

            // Går til oversigtsside (kan ændres til den ønskede side)
            return RedirectToPage("/AnimalList");
        }
    }
}

