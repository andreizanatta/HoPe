using MediatR;

namespace HoPe.Application.Commands.CreateReservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public int IdClient { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string UserCreated { get; set; }
    }
}
