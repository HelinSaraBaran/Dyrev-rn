using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IActivitySignupRepository
    {
        void Add(ActivitySignup signup);             // Tilføj én tilmelding
        List<ActivitySignup> GetAll();               // Hent alle tilmeldinger
        void SaveAll(List<ActivitySignup> signups);  // Gem listen (hvis nødvendigt)
    }
}
