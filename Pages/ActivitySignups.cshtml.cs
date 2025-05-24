using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;

namespace Dyreværn.Pages
{
    // PageModel for siden, der viser alle tilmeldinger til aktiviteter
    public class ActivitySignupsModel : PageModel
    {
        // Liste til at holde alle aktivitetstilmeldinger
        public List<ActivitySignup> Signups { get; set; } = new List<ActivitySignup>();

        // Metode der kaldes når siden indlæses (GET)
        public void OnGet()
        {
            // Opretter service-instans for at hente data
            ActivitySignupService service = new ActivitySignupService();

            // Henter alle tilmeldinger via service og gemmer i Signups
            Signups = service.GetAllSignups();
        }
    }
}

