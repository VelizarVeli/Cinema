using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketCanceledReservationValidation : INewTicketWithReservation
    {
        private readonly IReservationRepository reservationRepo;
        private readonly INewTicketWithReservation newTicketWithRes;

        public NewTicketCanceledReservationValidation(IReservationRepository reservationRepo, INewTicketWithReservation newTicketWithRes)
        {
            this.reservationRepo = reservationRepo;
            this.newTicketWithRes = newTicketWithRes;
        }

        public NewTicketWithReservationSummary New(ITicketWithReservationCreation ticket)
        {

            IReservation reservation = reservationRepo.GetReservationyId(ticket.ReservationId);

            if (reservation.Canceled)
            {
                return new NewTicketWithReservationSummary(false, $"You can't purchase a ticket as reservation with id {reservation.Id} has already been canceled");
            }

            reservationRepo.CancelReservation(reservation);

            return newTicketWithRes.New(ticket);
        }
    }
}