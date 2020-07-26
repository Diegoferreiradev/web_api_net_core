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
                new Reservation { ReservaId = 1, Nome = "Diego Ferreira", InicioLocalizacao = "Recife", FimLocalizacao = "Av.Marquês de Olinda" },
                new Reservation { ReservaId = 2, Nome = "Severina", InicioLocalizacao = "Jaboatão dos Guararapes", FimLocalizacao = "Av.Emirates" },
                new Reservation { ReservaId = 3, Nome = "Jucelino", InicioLocalizacao = "São Paulo", FimLocalizacao = "Av.Paulista" },
                new Reservation { ReservaId = 4, Nome = "Lampião", InicioLocalizacao = "Piedade", FimLocalizacao = "Praia de Piedade" },
                new Reservation { ReservaId = 5, Nome = "Maria Bonita", InicioLocalizacao = "Av.Bernardo Vieira", FimLocalizacao = "Praia de Candeias" }

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
