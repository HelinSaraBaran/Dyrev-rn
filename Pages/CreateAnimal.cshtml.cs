using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;

namespace Dyreværn.Pages
{
    public class CreateAnimalModel : PageModel
    {
        [BindProperty]
        public Animal Animal { get; set; }

        private AnimalService _animalService;

        public CreateAnimalModel()
        {
            _animalService = new AnimalService();
        }

        public void OnGet()
        {
            Animal = new Animal();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _animalService.AddAnimal(Animal);
            return RedirectToPage("/AnimalList"); // Skift til korrekt side hvis du ikke har AnimalList
        }
    }
}
