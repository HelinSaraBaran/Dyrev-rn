using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;

namespace Dyreværn.Pages
{
    // PageModel til oversigt, tilføjelse og fjernelse af medarbejdere
    public class EmployeeListModel : PageModel
    {
        // Liste med alle medarbejdere som vises i tabellen
        public List<Employee> Employees { get; set; } = new List<Employee>();

        // Formularfelter til tilføjelse af medarbejder
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Role { get; set; }

        // Formularfelt til sletning (indtastet ID)
        [BindProperty]
        public int RemoveId { get; set; }

        // Service der håndterer medarbejderdata
        private EmployeeService _service = new EmployeeService();

        // Kører når siden vises (GET) – henter medarbejdere
        public void OnGet()
        {
            Employees = _service.GetAll();
        }

        // Kører når brugeren tilføjer en ny medarbejder (POST)
        public IActionResult OnPostAdd()
        {
            if (!ModelState.IsValid)
            {
                Employees = _service.GetAll();
                return Page();
            }

            // Opretter ny medarbejder
            Employee newEmployee = new Employee
            {
                Name = Name,
                Email = Email,
                Role = Role
            };

            _service.Add(newEmployee);

            return RedirectToPage(); // Genindlæs siden
        }

        // Kører når brugeren vil fjerne en medarbejder (POST)
        public IActionResult OnPostRemove()
        {
            _service.RemoveById(RemoveId);

            return RedirectToPage(); // Genindlæs siden
        }
    }
}
