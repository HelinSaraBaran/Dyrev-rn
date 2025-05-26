using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;

namespace Dyreværn.Pages
{
    // PageModel for siden, der viser alle tilmeldinger til aktiviteter
    public class ActivitySignupsModel : PageModel
    {
        // Liste med alle tilmeldinger
        public List<ActivitySignup> Signups { get; set; } = new List<ActivitySignup>();

        // Index på den tilmelding der skal fjernes (fra formular)
        [BindProperty]
        public int IndexToRemove { get; set; }

        public void OnGet()
        {
            // Henter alle tilmeldinger via service
            ActivitySignupService service = new ActivitySignupService();
            Signups = service.GetAllSignups();
        }

        // POST – fjerner en tilmelding ud fra index
        public IActionResult OnPostRemoveSignup()
        {
            ActivitySignupService service = new ActivitySignupService();
            List<ActivitySignup> allSignups = service.GetAllSignups();

            // Fjern tilmelding hvis index er gyldigt
            if (IndexToRemove >= 0 && IndexToRemove < allSignups.Count)
            {
                allSignups.RemoveAt(IndexToRemove);
                service.SaveAll(allSignups);
            }

            Signups = allSignups; // Opdater listen til visning
            return RedirectToPage(); // Genindlæs siden
        }
    }
}


