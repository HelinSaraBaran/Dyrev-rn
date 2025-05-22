// Codebehind til BookVisit-siden
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using System;

namespace Dyreværn.Pages
{
    public class BookVisitModel : PageModel
    {
        // Dyrets ID bliver sendt med i URL'en (?animalId=1)
        [BindProperty(SupportsGet = true)]
        public int AnimalId { get; set; }

        // Navnet på det valgte dyr – vises øverst på siden
        public string AnimalName { get; set; }

        // Brugeren skriver sit navn
        [BindProperty]
        public string VisitorName { get; set; }

        // Brugeren skriver sin e-mail
        [BindProperty]
        public string Email { get; set; }

        // Brugeren vælger dato for besøget
        [BindProperty]
        public DateTime VisitDate { get; set; }

        // Bruges til at vise bekræftelse efter booking
        public bool Success { get; set; } = false;

        // Når siden indlæses via GET (før formularen sendes)
        public void OnGet()
        {
            // Opretter service og henter alle dyr
            AnimalService service = new AnimalService();
            Animal selectedAnimal = service.GetAllAnimals().Find(a => a.Id == AnimalId);

            // Finder dyrets navn ud fra det valgte ID
            if (selectedAnimal != null)
            {
                AnimalName = selectedAnimal.Name;
            }
        }

        // Når brugeren trykker "Book besøg" (POST)
        public void OnPost()
        {
            // Opretter nyt visit-objekt med data fra formular
            Visit newVisit = new Visit
            {
                VisitorName = VisitorName,
                Email = Email,
                VisitDate = VisitDate,
                AnimalName = AnimalName
            };

            // Tilføjer visit til den midlertidige liste
            VisitService visitService = new VisitService();
            visitService.AddVisit(newVisit);

            // Viser bekræftelse
            Success = true;
        }

    }
}
