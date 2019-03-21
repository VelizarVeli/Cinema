using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketNoResAlreadyReservedAndPurchasedSeatsValidation : INewTicketNoRes
    {
        private readonly ITicketRepository ticketRepo;
        private readonly INewTicketNoRes _newTicketNoRes;

        public NewTicketNoResAlreadyReservedAndPurchasedSeatsValidation(ITicketRepository ticketRepo, INewTicketNoRes newTicketNoRes)
        {
            this.ticketRepo = ticketRepo;
            this._newTicketNoRes = newTicketNoRes;
        }

        public NewTicketSummary New(ITicketCreation ticket)
        {
            IEnumerable<IReservation> reservedSeats = ticketRepo.GetReservedSeats(ticket.ProjectionId);
            IEnumerable<ITicket> purchasedSeats = ticketRepo.GetPurchasedSeats(ticket.ProjectionId);

            bool checkReservations = reservedSeats.Any(x => x.Row == ticket.Row && x.Column == ticket.Column);
            bool checkTickets = purchasedSeats.Any(x => x.Row == ticket.Row && x.Column == ticket.Column);

            if (checkReservations || checkTickets)
            {
                return new NewTicketSummary(false, "This seat is reserved");
            }

            return _newTicketNoRes.New(ticket);
        }
    }
}