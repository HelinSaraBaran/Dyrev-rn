using System;

namespace Domain.Models
{
    public class VisitLogEntry
    {
        public DateTime Date { get; set; }      // Dato for besøget
        public string Type { get; set; }        // F.eks. "Dyrlægebesøg" eller "Kunde"
        public string Notes { get; set; }       // Noter om besøget
    }
}
