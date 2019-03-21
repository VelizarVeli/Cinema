using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationCreation : INewReservation
    {
        private readonly IReservationRepository reservationsRepo;

        public NewReservationCreation(IReservationRepository reservationsRepo)
        {
            this.reservationsRepo = reservationsRepo;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            reservationsRepo.Insert(new Reservation(reservation.ProjectionId, reservation.Column, reservation.Row));

            return new NewReservationSummary(true);
        }
    }
}