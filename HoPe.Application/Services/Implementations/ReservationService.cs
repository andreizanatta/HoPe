using HoPe.Application.InputModels;
using HoPe.Application.Services.Interfaces;
using HoPe.Application.ViewModels;
using HoPe.Core.Entities;
using HoPe.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoPe.Application.Services.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly HoPeDbContext _dbContext;
        public ReservationService(HoPeDbContext hoPeDbContext)
        {
            _dbContext = hoPeDbContext;
        }

        public int Create(CreateReservationInputModel createReservationModel)
        {
            var reservation = new Reservation(createReservationModel.Date, 
                                              createReservationModel.Comment, 
                                              createReservationModel.IdClient, 
                                              createReservationModel.UserCreated);

            _dbContext.Reservations.Add(reservation);
            return reservation.Id;
        }

        public void Delete(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(reservation => reservation.Id == id);
            reservation?.Cancel();
        }

        public void Finish(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(reservation => reservation.Id == id);
            reservation?.Finish();
        }

        public List<ReservationViewModel> Get(string query)
        {
            var reservations = _dbContext.Reservations.AsQueryable();

            var reservationsViewModel = reservations.Select(r => new ReservationViewModel()
            {
                Date = r.Date,
                Comment = r.Comment,
                UserCreated = r.UserCreated,
            }).ToList();

            return reservationsViewModel;
        }

        public ReservationDetailsViewModel GetById(int id)
        {
            var reservation = _dbContext.Reservations.Single(r => r.Id == id);

            var reservationDetailsViewModel = new ReservationDetailsViewModel()
            {
                Date = reservation.Date,
                Comment = reservation.Comment,
                UserCreated = reservation.UserCreated,
            };

            return reservationDetailsViewModel;
        }

        public void Start(int id)
        {
            var reservation = _dbContext.Reservations.FirstOrDefault(reservation => reservation.Id == id);
            reservation?.Start();
        }

        public void Update(UpdateReservationInputModel updateReservationModel)
        {
            var reservation = _dbContext.Reservations.Single(r => r.Id == updateReservationModel.Id);
            reservation.Update(updateReservationModel.Date, updateReservationModel.Comment);
        }
    }
}
