using System.Collections.Generic;

namespace Domain.Models
{
    // Model der repræsenterer et dyr i systemet
    public class Animal
    {
        public int Id { get; set; }                 // Unikt ID for dyret
        public string Name { get; set; }            // Navn
        public string Species { get; set; }         // Art: fx Hund, Kat, Kanin
        public string Race { get; set; }            // Race
        public string Gender { get; set; }          // Han eller Hun
        public string ChipNumber { get; set; }      // Unikt chipnummer
        public string SpecialMarks { get; set; }    // Kendetegn
        public string Size { get; set; }            // Lille, Mellem, Stor
        public int BirthYear { get; set; }          // Fødselsår
        public bool IsSterilized { get; set; }      // Er dyret steriliseret
        public bool IsVaccinated { get; set; }      // Er dyret vaccineret
        public string ImagePath { get; set; }       // Sti til billede
        public string Description { get; set; }     // Kort beskrivelse

        // Liste med log over tidligere besøg (kunde eller dyrlæge)
        public List<VisitLogEntry> VisitLog { get; set; } = new List<VisitLogEntry>();

        public override string ToString()
        {
            return $"Id: {Id}, Navn: {Name}, Art: {Species}, Køn: {Gender}";
        }
    }
}
