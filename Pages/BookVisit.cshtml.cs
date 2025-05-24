using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using System.Collections.Generic;
using System;

namespace Dyreværn.Pages
{
    // PageModel til booking af besøg hos et bestemt dyr
    public class BookVisitModel : PageModel
    {
        // Dyrets ID (sendes som query parameter)
        [BindProperty(SupportsGet = true)]
        public int AnimalId { get; set; }

        // Navnet på det valgte dyr
        public string AnimalName { get; set; }

        // Brugeren indtaster navn
        [BindProperty]
        public string VisitorName { get; set; }

        // Brugeren indtaster e-mail
        [BindProperty]
        public string Email { get; set; }

        // Brugeren vælger dato for besøget
        [BindProperty]
        public DateTime VisitDate { get; set; }

        // Viser bekræftelse efter booking
        public bool Success { get; set; } = false;

        // GET – vis siden og find dyrets navn
        public void OnGet()
        {
            AnimalService service = new AnimalService();
            List<Animal> animals = service.GetAllAnimals();

            // Find dyret med det ID brugeren klikkede på
            foreach (Animal animal in animals)
            {
                if (animal.Id == AnimalId)
                {
                    AnimalName = animal.Name;
                    break;
                }
            }
        }

        // POST – håndter formular og gem booking
        public void OnPost()
        {
            // Opretter en ny booking
            Visit booking = new Visit();
            booking.VisitorName = VisitorName;
            booking.Email = Email;
            booking.AnimalName = AnimalName;
            booking.VisitDate = VisitDate;

            // Gem bookingen via service
            BookingService bookingService = new BookingService();
            bookingService.AddBooking(booking);

            // Vis bekræftelse
            Success = true;
        }
    }
}

