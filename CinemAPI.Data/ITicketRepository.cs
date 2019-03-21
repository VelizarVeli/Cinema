using System.Collections.Generic;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Data
{
    public interface ITicketRepository
    {
        void Insert(ITicketCreation ticket);

        IEnumerable<ITicket> GetPurchasedSeats(long reservationId);

        IEnumerable<IReservation> GetReservedSeats(long projectionId);

        ITicketDto CreateTicket(long projectionId, short row, short column);
    }
}