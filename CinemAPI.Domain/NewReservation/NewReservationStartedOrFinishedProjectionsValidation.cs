using System;
using CinemAPI.Data;
using CinemAPI.Data.Implementation.Constants;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;
using CinemAPI.Models.Contracts.Reservation;
namespace CinemAPI.Domain.NewReservation
{
    public class NewReservationStartedOrFinishedProjectionsValidation : INewReservation
    {
        private readonly IProjectionRepository projRepo;
        private readonly INewReservation newRes;

        public NewReservationStartedOrFinishedProjectionsValidation(IProjectionRepository projRepo, INewReservation newRes)
        {
            this.projRepo = projRepo;
            this.newRes = newRes;
        }

        public NewReservationSummary New(IReservationCreation reservation)
        {
            IProjection projection = projRepo.GetById(reservation.ProjectionId);

            DateTime now = DateTime.UtcNow.AddMinutes(ActionConstants.MinutesToProjection);

            if (projection.StartDate < now)
            {
                return new NewReservationSummary(false, "You have to make a reservation at least 10 minutes prior to the begining of the projection!");
            }

            return newRes.New(reservation);
        }
    }
}