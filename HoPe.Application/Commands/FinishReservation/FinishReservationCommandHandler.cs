using HoPe.Core.Repositories;
using MediatR;

namespace HoPe.Application.Commands.FinishReservation
{
    public class FinishReservationCommandHandler : IRequestHandler<FinishReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        public FinishReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(FinishReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            reservation?.Start();
            await _reservationRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
