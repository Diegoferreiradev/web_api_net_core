using Microsoft.AspNetCore.Mvc;
using MVC_Reservation.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public ViewResult GetReservation() => View();
        [HttpPost]
        public async Task<IActionResult> GetReservation(int id)
        {
            Reservation reservation = new Reservation();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservation);
        }

        public ViewResult AddReservation() => View();
        [HttpPost]
        public async Task<IActionResult> AddReservation(Reservation reservation)
        {
            Reservation reservationSend = new Reservation();

            using (var httpCliente = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");
                using (var response = await httpCliente.PostAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationSend = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }

            return View(reservationSend);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            Reservation reservation = new Reservation();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(apiUrl + "/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservation = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservation);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservation(Reservation reservation)
        {
            Reservation reservationSend = new Reservation();

            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(reservation.ReservaId.ToString()), "ReservaId");
                content.Add(new StringContent(reservation.Nome), "Nome");
                content.Add(new StringContent(reservation.InicioLocacao), "InicioLocacao");
                content.Add(new StringContent(reservation.FimLocacao), "FimLocacao");

                using (var response = await httpClient.PutAsync(apiUrl, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Sucesso";
                    reservationSend = JsonConvert.DeserializeObject<Reservation>(apiResponse);
                }
            }
            return View(reservationSend);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(apiUrl + "/" + reservationId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }

}

