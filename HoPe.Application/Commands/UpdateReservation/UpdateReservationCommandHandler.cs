using HoPe.Core.Repositories;
using HoPe.Infrastructure.Persistence;
using MediatR;

namespace HoPe.Application.Commands.UpdateReservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Unit>
    {
        private readonly IReservationRepository _reservationRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);
            reservation.Update(request.Date, request.Comment);
            await _reservationRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
