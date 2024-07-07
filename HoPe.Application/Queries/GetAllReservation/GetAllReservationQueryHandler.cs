using HoPe.Application.ViewModels;
using HoPe.Core.Repositories;
using MediatR;

namespace HoPe.Application.Queries.GetAllReservation
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQuery, List<ReservationViewModel>>
    {
        private readonly IReservationRepository _reservationRepository;
        public GetAllReservationQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<ReservationViewModel>> Handle(GetAllReservationQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetAllAsync();

            var reservationsViewModel = reservations.Select(r => new ReservationViewModel()
            {
                Date = r.Date,
                Comment = r.Comment,
                UserCreated = r.UserCreated,
            }).ToList();

            return reservationsViewModel;
        }
    }
}
