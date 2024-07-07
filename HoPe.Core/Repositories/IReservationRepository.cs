using HoPe.Core.Entities;

namespace HoPe.Core.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetAllAsync();
        Task<Reservation> GetByIdAsync(int id);
        Task AddAsync(Reservation reservation);
        Task SaveChangesAsync();
    }
}
