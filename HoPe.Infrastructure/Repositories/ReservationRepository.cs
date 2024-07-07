using Azure.Core;
using HoPe.Core.Entities;
using HoPe.Core.Repositories;
using HoPe.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HoPe.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly HoPeDbContext _dbContext;
        public ReservationRepository(HoPeDbContext hoPeDbContext)
        {
            _dbContext = hoPeDbContext;
        }

        public async Task AddAsync(Reservation reservation)
        {
            await _dbContext.Reservations.AddAsync(reservation);
            await SaveChangesAsync();
        }

        public async Task<List<Reservation>> GetAllAsync()
        {
            return await _dbContext.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _dbContext.Reservations.SingleAsync(r => r.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
