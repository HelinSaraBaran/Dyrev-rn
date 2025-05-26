using System.Collections.Generic;
using Domain.Models;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace Service
{
    // Serviceklasse der arbejder med bookinger via repository
    public class BookingService
    {
        private IBookingRepository _repository;

        // Constructor – bruger BookingRepository som datakilde
        public BookingService()
        {
            _repository = new BookingRepository();
        }

        // Returnerer alle bookinger (besøg)
        public List<Visit> GetAllBookings()
        {
            return _repository.GetAll();
        }

        // Tilføjer en ny booking
        public void AddBooking(Visit visit)
        {
            _repository.Add(visit);
        }

        // Overskriver og gemmer hele listen (valgfrit)
        public void SaveAllBookings(List<Visit> visits)
        {
            _repository.SaveAll(visits);
        }
    }
}
