namespace CinemAPI.Models.Contracts.Ticket
{
   public interface ITicketWithReservationCreation
    {
        long ReservationId { get; set; }

        long ProjectionId { get; set; }

        short Row { get; set; }

        short Column { get; set; }
    }
}
