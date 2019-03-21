using System;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewTicket
{
    public class NewTicketNoResStartedOrFinishedProjectionsValidation : INewTicketNoRes
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewTicketNoRes _newTicketNoRes;

        public NewTicketNoResStartedOrFinishedProjectionsValidation(IProjectionRepository projRepo, INewTicketNoRes newTicketNoRes)
        {
            this.projRepo = projRepo;
            this._newTicketNoRes = newTicketNoRes;
        }

        public NewTicketSummary New(ITicketCreation ticket)
        {
            IProjection projection = projRepo.GetById(ticket.ProjectionId);

            DateTime now = DateTime.UtcNow;

            if (projection.StartDate < now)
            {
                return new NewTicketSummary(false, "You have to purchase a ticket before beginning of the projection!");
            }

            return _newTicketNoRes.New(ticket);
        }
    }
}