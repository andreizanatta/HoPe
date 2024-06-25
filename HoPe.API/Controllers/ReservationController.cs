using HoPe.API.Models;
using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HoPe.API.Controllers
{
    [Route("api/reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var reservation = _reservationService.GetById(id);
            return Ok(reservation);
        }

        [HttpGet("query")]
        public IActionResult Get(string query) 
        {
            var reservations = _reservationService.Get(query);
            return Ok(reservations);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateReservationInputModel createReservationInputModel)
        {
            var id = _reservationService.Create(createReservationInputModel);
            return CreatedAtAction(nameof(GetById), new { id }, createReservationInputModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateReservationInputModel updateReservationInputModel)
        {
            _reservationService.Update(updateReservationInputModel);
            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _reservationService.Delete(id);
            return NoContent();
        }

        [HttpPut("id/start")]
        public IActionResult Start(int id)
        {
            _reservationService.Start(id);
            return NoContent();
        }

        [HttpPut("id/finish")]
        public IActionResult Finish(int id)
        {
            _reservationService.Finish(id);
            return NoContent();
        }
    }
}
