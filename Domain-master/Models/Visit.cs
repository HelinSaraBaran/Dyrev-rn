namespace Domain.Models
{
    // Model for et besøg/bookingaftale
    public class Visit
    {
        public string VisitorName { get; set; }     // Navn på personen der booker
        public string Email { get; set; }           // Emailadresse
        public DateTime VisitDate { get; set; }     // Dato for besøget
        public string AnimalName { get; set; }      // Navn på dyret

        public override string ToString()
        {
            return $"Navn: {VisitorName}, Dyr: {AnimalName}, Dato: {VisitDate.ToShortDateString()}";
        }
    }
}
