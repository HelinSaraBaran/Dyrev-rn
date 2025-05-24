using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Domain.Models;       // Bruger Visit-modellen
using Service;

namespace Dyreværn.Pages
{
    // Model til visning af bookingoversigten
    public class BookingOverviewModel : PageModel
    {
        // Liste over alle bookinger (besøg) som vises i tabellen
        public List<Visit> Bookings { get; set; } = new List<Visit>();

        // Kører når siden åbnes – henter bookinger fra service
        public void OnGet()
        {
            // Opretter service og henter alle bookinger
            BookingService service = new BookingService();
            Bookings = service.GetAllBookings();
        }
    }
}


