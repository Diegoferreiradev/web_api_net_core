using Microsoft.AspNetCore.Mvc;
using MVC_Reservation.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC_Reservation.Controllers
{
    public class ReservationController : Controller
    {
        private readonly string apiUrl = "https://localhost:44336/api/reservation";

        public async Task<IActionResult> Index()
        {
            List<Reservation> listReservations = new List<Reservation>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    listReservations = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
            }

            return View(listReservations);
        }
    }
}

