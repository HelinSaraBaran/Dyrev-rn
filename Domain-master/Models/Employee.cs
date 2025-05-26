using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Model der repræsenterer en medarbejder
namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }             // Medarbejderens ID
        public string Name { get; set; }        // Navn
        public string Email { get; set; }       // E-mail
        public string Role { get; set; }        // Rolle (f.eks. Dyrepasser)

        public override string ToString()
        {
            return $"Id: {Id}, Navn: {Name}, Rolle: {Role}";
        }
    }
}
