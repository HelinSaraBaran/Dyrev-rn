using System;

namespace Domain.Models
{
    public class ActivitySignup
    {
        public string Name { get; set; }         // Navn på deltager
        public string Email { get; set; }        // E-mailadresse
        public string Activity { get; set; }     // Navn på aktivitet
        public DateTime SignupDate { get; set; } // Hvornår de tilmeldte sig
    }
}
