using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        // Henter alle medarbejdere
        List<Employee> GetAll();

        // Tilføjer en ny medarbejder
        void Add(Employee employee);

        // Fjerner en medarbejder baseret på ID
        void RemoveById(int id);

        // Henter en bestemt medarbejder (valgfrit – bruges hvis du vil vise detaljer)
        Employee GetById(int id);

        // Gemmer hele listen (hvis du arbejder med filer/lister som data)
        void SaveAll(List<Employee> employees);
    }
}
