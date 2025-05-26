using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Domain.Models;       
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
            BookingService service = new BookingService();
            Bookings = service.GetAllBookings();
        }

        // Kører når der trykkes "Slet" – fjerner booking ud fra ID
        public IActionResult OnPostDelete(int id)
        {
            BookingService service = new BookingService();
            service.DeleteBooking(id);
            return RedirectToPage(); // Genindlæser siden
        }
    }
}

