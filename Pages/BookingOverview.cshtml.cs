using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Domain.Models;
using Service;

namespace Dyreværn.Pages
{
    // Model til visning af bookingoversigten
    public class BookingOverviewModel : PageModel
    {
        // Liste over alle bookinger som vises i tabellen
        public List<Booking> Bookings { get; set; } = new List<Booking>();

        // Kører når siden åbnes – henter bookinger fra service
        public void OnGet()
        {
            // Opretter service og henter alle bookinger
            BookingService service = new BookingService();
            Bookings = service.GetAllBookings();
        }
    }
}

