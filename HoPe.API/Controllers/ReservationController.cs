using HoPe.Application.Commands.CreateReservation;
using HoPe.Application.Commands.DeleteReservation;
using HoPe.Application.Commands.FinishReservation;
using HoPe.Application.Commands.StartReservation;
using HoPe.Application.Commands.UpdateReservation;
using HoPe.Application.Queries.GetAllReservation;
using HoPe.Application.Queries.GetByIdReservation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HoPe.API.Controllers
{
    [Route("api/reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            //var reservation = _reservationService.GetById(id);
            var reservationCommand = new GetByIdReservationQuery { Id = id };
            var reservation = await _mediator.Send(reservationCommand);
            return Ok(reservation);
        }

        [HttpGet("query")]
        public IActionResult Get(string query) 
        {
            var reservationsCommand = new GetAllReservationQuery { Query = query};
            var reservations = _mediator.Send(reservationsCommand);
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservationCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateReservationCommand command)
        {
            //_reservationService.Update(updateReservationInputModel);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //_reservationService.Delete(id);
            var deleteReservationCommand = new DeleteReservationCommand { Id = id };
            await _mediator.Send(deleteReservationCommand);
            return NoContent();
        }

        [HttpPut("id/start")]
        public async Task<IActionResult> Start(int id)
        {
            //_reservationService.Start(id);
            var startCommand = new StartReservationCommand { Id=id };
            await _mediator.Send(startCommand);
            return NoContent();
        }

        [HttpPut("id/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            //_reservationService.Finish(id);
            var finishCommand = new FinishReservationCommand { Id = id };
            await _mediator.Send(finishCommand);
            return NoContent();
        }
    }
}
