using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Reservation.Models
{
    public class Reservation
    {
        public int ReservaId { get; set; }
        public string Nome { get; set; }
        public string InicioLocalizacao { get; set; }
        public string FimLocalizacao { get; set; }
    }
}
