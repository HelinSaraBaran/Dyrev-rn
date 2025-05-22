using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
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

        // Instans af service
        private EmployeeService _service = new EmployeeService();

        // Viser siden og henter alle medarbejdere
        public void OnGet()
        {
            Employees = _service.GetAllEmployees();
        }

        // Tilføjer en ny medarbejder
        public IActionResult OnPostAdd()
        {
            Employee newEmployee = new Employee
            {
                Id = new System.Random().Next(1000, 9999), 
                Name = Name,
                Email = Email,
                Role = Role
            };

            _service.AddEmployee(newEmployee);
            return RedirectToPage();
        }

        // Fjerner en medarbejder
        public IActionResult OnPostRemove()
        {
            _service.RemoveEmployee(RemoveId);
            return RedirectToPage();
        }
    }
}
