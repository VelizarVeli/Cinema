namespace CinemAPI.Models.Contracts.Reservation
{
    public interface IReservation
    {
        long Id { get; set; }

        long ProjectionId { get; set; }

        short Row { get; set; }

        short Column { get; set; }

        bool Canceled { get; set; }
    }
}
