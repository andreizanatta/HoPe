using HoPe.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HoPe.Infrastructure.Configuration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.
                HasOne(r => r.Pet).
                WithMany(c => c.Reservations).
                HasForeignKey(r => r.IdPet).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
