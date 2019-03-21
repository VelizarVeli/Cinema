using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationAlreadyReservedSeatsValidation : INewReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewReservation newRes;

        public NewReservationAlreadyReservedSeatsValidation(IReservationRepository reservationRepo, INewReservation newRes)
        {
            this.reservationRepo = reservationRepo;
            this.newRes = newRes;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            IEnumerable<IReservation> reservedSeats = reservationRepo.GetReservedSeats(reservation.ProjectionId);

            bool checkSeat = reservedSeats.Any(x => x.Row == reservation.Row && x.Column == reservation.Column);

            if (checkSeat)
            {
                return new NewReservationSummary(false, "This seat is already reserved");
            }

            return newRes.New(reservation);
        }
    }
}