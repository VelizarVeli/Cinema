namespace CinemAPI.Models.Contracts.Reservation
{
   public interface IReservationCreation
    {
        long ProjectionId { get; set; }

        short Row { get; set; }

        short Column { get; set; }
    }
}
