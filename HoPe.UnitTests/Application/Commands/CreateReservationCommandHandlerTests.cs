﻿using HoPe.Application.Commands.CreateReservation;
using HoPe.Core.Entities;
using HoPe.Core.Repositories;
using HoPe.Infrastructure.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.UnitTests.Application.Commands
{
    public class CreateReservationCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOK_Executed_ReturnedReservationID()
        {
            //Arrange
            var reservation = new CreateReservationCommand()
            {
                Date = DateTime.Now, Comment = "",IdClient = 1, UserCreated = "andrei"
            };

            var reservationRepository = new Mock<IReservationRepository>();
            var reservationHandler = new CreateReservationCommandHandler(reservationRepository.Object);
            //Act
            var id = await reservationHandler.Handle(reservation, new CancellationToken());

            //Assert
            Assert.True(id > 0);

            reservationRepository.Verify(r => r.AddAsync(It.IsAny<Reservation>()), Times.Once);
        }
    }
}
