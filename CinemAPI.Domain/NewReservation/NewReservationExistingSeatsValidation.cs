using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationExistingSeatsValidation : INewReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewReservation newRes;

        public NewReservationExistingSeatsValidation(IReservationRepository reservationRepo, INewReservation newRes)
        {
            this.reservationRepo = reservationRepo;
            this.newRes = newRes;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            IRoom room = reservationRepo.GetRoomById(reservation.ProjectionId);

            bool checkSeatExistence = room.Rows < reservation.Row ||
                                      room.SeatsPerRow < reservation.Column ||
                                      reservation.Row <= 0 ||
                                      reservation.Column <= 0;

            if (checkSeatExistence)
            {
                return new NewReservationSummary(false, "This seat does not exist");
            }

            return newRes.New(reservation);
        }
    }
}