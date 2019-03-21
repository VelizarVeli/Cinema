using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketNoResCreation : INewTicketNoRes
    {
        private readonly ITicketRepository ticketsRepo;

        public NewTicketNoResCreation(ITicketRepository ticketsRepo)
        {
            this.ticketsRepo = ticketsRepo;
        }

        public NewTicketSummary New(ITicketCreation ticket)
        {
            ticketsRepo.Insert(new Ticket(ticket.ProjectionId, ticket.Row, ticket.Column));

            return new NewTicketSummary(true);
        }
    }
}