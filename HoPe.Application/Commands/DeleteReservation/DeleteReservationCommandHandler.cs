using HoPe.Core.Repositories;
using MediatR;

namespace HoPe.Application.Commands.DeleteReservation
{
    public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;
        public DeleteReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            reservation?.Cancel();
            await _reservationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
