using HoPe.Application.ViewModels;
using MediatR;

namespace HoPe.Application.Queries.GetAllReservation
{
    public class GetAllReservationQuery : IRequest<List<ReservationViewModel>>
    {
        public string Query { get; set; }
    }
}
