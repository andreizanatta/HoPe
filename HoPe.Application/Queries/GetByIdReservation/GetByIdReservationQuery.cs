using HoPe.Application.ViewModels;
using MediatR;

namespace HoPe.Application.Queries.GetByIdReservation
{
    public class GetByIdReservationQuery : IRequest<ReservationDetailsViewModel>
    {
        public int Id { get; set; }
    }
}
