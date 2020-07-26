using APIReservation.Models;
using System.Collections.Generic;

namespace APIReservation.Services
{
    public interface IRepository
    {
        IEnumerable<Reservation> Reservas { get; }
        Reservation this[int id] { get; }
        Reservation AddReservation(Reservation reserva);
        Reservation UpdateReservation(Reservation reserva);
        void DeleteReservation(int id);
    }
}
