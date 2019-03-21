using CinemAPI.Domain;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.NewProjection;
using CinemAPI.Domain.NewReservation;
using CinemAPI.Domain.NewScheduler;
using CinemAPI.Domain.NewTicket;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DomainPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<INewProjection, NewProjectionCreation>();
            container.RegisterDecorator<INewProjection, NewProjectionMovieValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionUniqueValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionRoomValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionPreviousOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionNextOverlapValidation>();
            container.RegisterDecorator<INewProjection, NewProjectionAvailableSeatsCountValidation>();
            container.Register<INewReservation, NewReservationCreation>();
            container.RegisterDecorator<INewReservation, NewReservationStartedOrFinishedProjectionsValidation>();
            container.RegisterDecorator<INewReservation, NewReservationAlreadyReservedSeatsValidation>();
            container.RegisterDecorator<INewReservation, NewReservationExistingSeatsValidation>();
            container.Register<INewTicketNoRes, NewTicketNoResCreation>();
            container.RegisterDecorator<INewTicketNoRes, NewTicketNoResAlreadyReservedAndPurchasedSeatsValidation>();
            container.RegisterDecorator<INewTicketNoRes, NewTicketNoResStartedOrFinishedProjectionsValidation>();
            container.Register<INewTicketWithReservation, NewTicketWithResCreation>();
            container.RegisterDecorator<INewTicketWithReservation, NewTicketWithReservationTenMinutesPriorToProjectionsValidation>();
            container.RegisterDecorator<INewTicketWithReservation, NewTicketCanceledReservationValidation>();

            container.Register<INewScheduler, NewSchedulerCreation>();
        }
    }
}