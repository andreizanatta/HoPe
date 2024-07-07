using HoPe.Core.Entities;
using HoPe.Core.Enums;

namespace HoPe.UnitTests.Core.Entities
{
    public class ReservationTests
    {
        [Fact]
        public void TestIfReservationStartWorks()
        {
            var reservation = new Reservation(DateTime.Now, "comentário", 1, "andrei");

            Assert.NotNull(reservation.Comment);
            Assert.NotEmpty(reservation.Comment);

            Assert.NotNull(reservation.UserCreated);
            Assert.NotEmpty(reservation.UserCreated);

            Assert.Equal(ReservationStatusEnum.Created, reservation.Status);

            reservation.Start();

            Assert.Equal(ReservationStatusEnum.InProgress, reservation.Status);

            Assert.NotNull(reservation.StartedAt);
        }
    }
}
