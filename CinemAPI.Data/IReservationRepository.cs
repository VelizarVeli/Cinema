using System.Collections.Generic;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Data
{
    public interface IReservationRepository
    {
        void Insert(IReservationCreation reservation);

        IEnumerable<IReservation> GetReservedSeats(long reservationId);

        IRoom GetRoomById(long id);

        IReservationDto CreateReservationTicket(long projectionId, short row, short column);

        IReservation GetReservationyId(long id);

        void CancelReservation(IReservation reservation);
    }
}