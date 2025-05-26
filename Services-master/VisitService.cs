using System.Collections.Generic;
using Domain.Models;

namespace Service
{
    public class VisitService
    {
        // Midlertidig liste med bookinger
        private static List<Visit> _visits = new List<Visit>();

        // Tilføjer en ny booking
        public void AddVisit(Visit visit)
        {
            _visits.Add(visit);
        }

        // Returnerer alle bookinger
        public List<Visit> GetAllVisits()
        {
            return _visits;
        }
    }
}
