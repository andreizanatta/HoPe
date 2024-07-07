using HoPe.Application.ViewModels;
using HoPe.Core.Repositories;
using HoPe.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HoPe.Application.Queries.GetByIdReservation
{
    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQuery, ReservationDetailsViewModel>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetByIdReservationQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<ReservationDetailsViewModel> Handle(GetByIdReservationQuery request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.Id);

            var reservationDetailsViewModel = new ReservationDetailsViewModel()
            {
                Date = reservation.Date,
                Comment = reservation.Comment,
                UserCreated = reservation.UserCreated,
            };

            return reservationDetailsViewModel;
        }
    }
}
