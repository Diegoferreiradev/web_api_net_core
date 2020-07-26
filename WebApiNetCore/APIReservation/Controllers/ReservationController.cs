using APIReservation.Models;
using APIReservation.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IRepository repository;

        public ReservationController(IRepository repo) => repository = repo;
        [HttpGet]
        public IEnumerable<Reservation> Get() => repository.Reservas;
        [HttpGet("{id}")]
        public Reservation Get(int id) => repository[id];
        [HttpPost]
        public Reservation Post([FromBody] Reservation res) => repository.AddReservation(
            new Reservation {
                Nome = res.Nome,
                InicioLocacao = res.InicioLocacao,
                FimLocacao = res.FimLocacao
            });

        [HttpPut]
        public Reservation Put([FromBody] Reservation res) => repository.UpdateReservation(res);

        [HttpPatch("{id}")]
        public StatusCodeResult Patch(int id, [FromForm] JsonPatchDocument<Reservation> patch)
        {
            Reservation res = Get(id);
            if (res != null)
            {
                patch.ApplyTo(res);
                return Ok();
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public void Delete(int id) => repository.DeleteReservation(id);
    }
}
