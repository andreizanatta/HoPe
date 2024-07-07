using MediatR;

namespace HoPe.Application.Commands.StartReservation
{
    public class StartReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
