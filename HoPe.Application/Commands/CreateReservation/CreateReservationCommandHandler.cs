using HoPe.Core.Entities;
using HoPe.Core.Repositories;
using MediatR;

namespace HoPe.Application.Commands.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IReservationRepository _reservationRepository;
        public CreateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation(request.Date, request.Comment, request.IdClient, request.UserCreated);

            await _reservationRepository.AddAsync(reservation);

            return reservation.Id;
        }
    }
}
