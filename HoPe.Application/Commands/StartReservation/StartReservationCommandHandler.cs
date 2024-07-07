using HoPe.Core.Repositories;
using MediatR;

namespace HoPe.Application.Commands.StartReservation
{
    public class StartReservationCommandHandler : IRequestHandler<StartReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        public StartReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(StartReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = _reservationRepository.GetByIdAsync(request.Id);
            reservation?.Start();
            await _reservationRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
