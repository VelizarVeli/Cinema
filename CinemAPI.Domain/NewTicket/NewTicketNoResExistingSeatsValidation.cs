using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketNoResExistingSeatsValidation : INewTicketNoRes
    {
        //private readonly ITicketRepository ticketRepo;
        //private readonly INewTicketNoRes newRes;

        //public NewTicketNoResExistingSeatsValidation(IReservationRepository reservationRepo, INewReservation newRes)
        //{
        //    this.reservationRepo = reservationRepo;
        //    this.newRes = newRes;
        //}

        //public NewReservationSummary New(IReservationCreation reservation)
        //{
        //    IRoom room = ticketRepo.GetRoomById(reservation.ProjectionId);

        //    bool checkSeatExistence = room.Rows < reservation.Row ||
        //                              room.SeatsPerRow < reservation.Column ||
        //                              reservation.Row <= 0 ||
        //                              reservation.Column <= 0;

        //    if (checkSeatExistence)
        //    {
        //        return new NewReservationSummary(false, "This seat does not exist");
        //    }

        //    return newRes.New(reservation);
        //}

        public NewTicketSummary New(ITicketCreation ticket)
        {
            throw new System.NotImplementedException();
        }
    }
}