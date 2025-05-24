using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Domain.Models;
using Service;
using System.Collections.Generic;

namespace Dyreværn.Pages
{
    public class EmployeeListModel : PageModel
    {
        // Liste med alle medarbejdere
        public List<Employee> Employees { get; set; } = new List<Employee>();

        // Formularfelter til tilføjelse
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Role { get; set; }

        // Formularfelt til sletning
        [BindProperty]
        public int RemoveId { get; set; }

        // Service der håndterer medarbejderdata
        private EmployeeService _service = new EmployeeService();

        // Kører når siden åbnes – henter alle medarbejdere
        public void OnGet()
        {
            Employees = _service.GetAllEmployees();
        }

        // Kører når man tilføjer en ny medarbejder
        public IActionResult OnPostAdd()
        {
            // Opretter nyt objekt og sætter data
            Employee newEmployee = new Employee();
            newEmployee.Name = Name;
            newEmployee.Email = Email;
            newEmployee.Role = Role;

            // Tilføjer medarbejderen via service
            _service.AddEmployee(newEmployee);

            // Går tilbage til siden (så vi undgår genindsendelse)
            return RedirectToPage();
        }

        // Kører når man vil fjerne en medarbejder
        public IActionResult OnPostRemove()
        {
            // Fjerner medarbejder med angivet ID
            _service.RemoveEmployee(RemoveId);

            // Går tilbage til siden
            return RedirectToPage();
        }
    }
}
