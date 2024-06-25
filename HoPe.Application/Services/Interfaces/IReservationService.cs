using HoPe.Application.InputModels;
using HoPe.Application.ViewModels;

namespace HoPe.Application.Services.Interfaces
{
    public interface IReservationService
    {
        List<ReservationViewModel> Get(string query);
        ReservationDetailsViewModel GetById(int id);

        int Create(CreateReservationInputModel CreateReservationModel);
        void Update(UpdateReservationInputModel UpdateReservationModel);
        void Delete(int id);
        void Start(int id);
        void Finish(int id);
    }
}
