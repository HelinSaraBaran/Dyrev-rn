using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using Service;
using System;

namespace Dyreværn.Pages
{
    // PageModel til aktivitets-siden med tilmeldingsformular
    public class ActivityModel : PageModel
    {
        // Brugeren skriver sit navn
        [BindProperty]
        public string Name { get; set; }

        // Brugeren skriver sin e-mail
        [BindProperty]
        public string Email { get; set; }

        // Brugeren vælger en aktivitet
        [BindProperty]
        public string SelectedActivity { get; set; }

        // Bruges til at vise bekræftelse
        public bool IsSuccess { get; set; } = false;

        // Når siden vises første gang (GET)
        public void OnGet()
        {
        }

        // Når brugeren sender formularen (POST)
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Hvis fejl i input
            }

            // Opretter ny tilmelding
            ActivitySignup signup = new ActivitySignup();
            signup.Name = Name;
            signup.Email = Email;
            signup.Activity = SelectedActivity;
            signup.SignupDate = DateTime.Now;

            // Gemmer tilmeldingen via service
            ActivitySignupService service = new ActivitySignupService();
            service.AddSignup(signup);

            // Viser bekræftelse
            IsSuccess = true;

            return Page();
        }
    }
}
