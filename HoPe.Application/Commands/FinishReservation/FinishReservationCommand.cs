using MediatR;

namespace HoPe.Application.Commands.FinishReservation
{
    public class FinishReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
