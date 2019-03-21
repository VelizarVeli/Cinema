using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Domain.Contracts
{
    public interface INewReservation
    {
        NewReservationSummary New(IReservationCreation reservation);
    }
}