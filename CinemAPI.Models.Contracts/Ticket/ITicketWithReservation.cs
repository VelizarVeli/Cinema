namespace CinemAPI.Models.Contracts.Ticket
{
    public interface ITicketWithReservation
    {
        long Id { get; set; }

        long ProjectionId { get; set; }

        short Row { get; set; }

        short Column { get; set; }
    }
}
