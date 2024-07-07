using MediatR;

namespace HoPe.Application.Commands.UpdateReservation
{
    public class UpdateReservationCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public DateTime Date { get; private set; }
        public string Comment { get; private set; }
        public int IdClient { get; private set; }
    }
}
