using HoPe.Application.Queries.GetAllReservation;
using HoPe.Core.Entities;
using HoPe.Core.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.UnitTests.Application.Queries
{
    public class GetAllReservationCommandHandlerTests
    {
        [Fact]
        public async  Task ThreeReservationExists_Executed_ReturnedThreeReservationViewModel()
        {
            //Arrange
            var reservations = new List<Reservation> { 
                new (DateTime.Now, "comentário", 1, "andrei"),
                new (DateTime.Now, "comentário 222", 1, "andrei"),
                new (DateTime.Now, "comentário 333", 1, "andrei")
            };

            var reservationRepository = new Mock<IReservationRepository>();
            reservationRepository.Setup(r => r.GetAllAsync().Result).Returns(reservations);

            var getAllReservationQuery = new GetAllReservationQuery();
            var getAllReservationQueryHandler = new GetAllReservationQueryHandler(reservationRepository.Object);

            //Act
            var reservationViewModelList = await getAllReservationQueryHandler.Handle(getAllReservationQuery, new CancellationToken());

            //Assert
            Assert.NotNull(reservationViewModelList);
            Assert.Equal(reservations.Count, reservationViewModelList.Count);

            reservationRepository.Verify(r => r.GetAllAsync().Result, Times.Once);
        }
    }
}
