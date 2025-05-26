using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Repositories;
using System.Collections.Generic;

namespace Service
{
    public class EmployeeService
    {
        private IEmployeeRepository _repository;

        public EmployeeService()
        {
            _repository = new EmployeeRepository();
        }

        // Returnerer alle medarbejdere
        public List<Employee> GetAll()
        {
            return _repository.GetAll();
        }

        // Tilføjer en ny medarbejder
        public void Add(Employee employee)
        {
            _repository.Add(employee);
        }

        // Fjerner en medarbejder via ID
        public void RemoveById(int id)
        {
            _repository.RemoveById(id);
        }
    }
}
