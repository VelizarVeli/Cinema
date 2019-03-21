using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketWithResCreation : INewTicketWithReservation
    {
        private readonly ITicketRepository ticketsRepo;

        public NewTicketWithResCreation(ITicketRepository ticketsRepo)
        {
            this.ticketsRepo = ticketsRepo;
        }

        public NewTicketWithReservationSummary New(ITicketWithReservationCreation ticket)
        {
            ticketsRepo.Insert(new Ticket(ticket.ProjectionId, ticket.Row, ticket.Column));

            return new NewTicketWithReservationSummary(true);
        }
    }
}