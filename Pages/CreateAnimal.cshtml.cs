using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace DyreVaernet2._0.Pages
{
    public class CreateAnimalModel : PageModel
    {
        [BindProperty]
        public Animal Animal { get; set; } = new Animal();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            IAnimalRepository repo = new AnimalRepository();
            repo.Add(Animal);

            // Gå tilbage til Adopter-siden når dyret er oprettet
            return RedirectToPage("/Adopt");
        }
    }
}
