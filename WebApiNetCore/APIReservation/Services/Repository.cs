using APIReservation.Models;
using System.Collections.Generic;

namespace APIReservation.Services
{
    public class Repository : IRepository
    {
        private Dictionary<int, Reservation> items;

        public Repository()
        {
            items = new Dictionary<int, Reservation>();

            new List<Reservation>
            {
                new Reservation { ReservaId = 1, Nome = "Diego Ferreira", InicioLocacao = "Recife", FimLocacao = "Av.Marquês de Olinda" },
                new Reservation { ReservaId = 2, Nome = "Severina", InicioLocacao = "Jaboatão dos Guararapes", FimLocacao = "Av.Emirates" },
                new Reservation { ReservaId = 3, Nome = "Jucelino", InicioLocacao = "São Paulo", FimLocacao = "Av.Paulista" },
                new Reservation { ReservaId = 4, Nome = "Lampião", InicioLocacao = "Piedade", FimLocacao = "Praia de Piedade" },
                new Reservation { ReservaId = 5, Nome = "Maria Bonita", InicioLocacao = "Av.Bernardo Vieira", FimLocacao = "Praia de Candeias" }

            }.ForEach( r => AddReservation(r));
        }

        public Reservation this[int id] => items.ContainsKey(id) ? items[id] : null;

        public IEnumerable<Reservation> Reservas => items.Values;

        public Reservation AddReservation(Reservation reserva)
        {
            if (reserva.ReservaId == 0)
            {
                int key = items.Count;
                while (items.ContainsKey(key)) { key++; };
                reserva.ReservaId = key;
            }
            items[reserva.ReservaId] = reserva;
            return reserva;
        }

        public void DeleteReservation(int id)
        {
            items.Remove(id);
        }

        public Reservation UpdateReservation(Reservation reserva)
        {
            AddReservation(reserva);
            return reserva;
        }
    }
}
