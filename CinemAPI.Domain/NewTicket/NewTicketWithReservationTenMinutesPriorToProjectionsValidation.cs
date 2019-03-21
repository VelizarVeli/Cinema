using System;
using CinemAPI.Data;
using CinemAPI.Data.Implementation.Constants;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Domain.NewReservation
{
    public class NewTicketWithReservationTenMinutesPriorToProjectionsValidation : INewTicketWithReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewTicketWithReservation newTicketWithRes;

        public NewTicketWithReservationTenMinutesPriorToProjectionsValidation(IProjectionRepository projRepo,
            INewTicketWithReservation newTicketWithRes)
        {
            this.projRepo = projRepo;
            this.newTicketWithRes = newTicketWithRes;
        }

        public NewTicketWithReservationSummary New(ITicketWithReservationCreation ticket)
        {
            IProjection projection = projRepo.GetById(ticket.ProjectionId);

            DateTime now = DateTime.UtcNow.AddMinutes(ActionConstants.MinutesToProjection);

            if (projection.StartDate < now)
            {
                return new NewTicketWithReservationSummary(false, "This reservation has been canceled. You have to purchase the ticket at least 10 minutes prior to the begining of the projection!");
            }

            return newTicketWithRes.New(ticket);
        }
    }
}