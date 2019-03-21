namespace CinemAPI.Models.Contracts.Ticket
{
   public interface ITicketCreation
    {
        long ProjectionId { get; set; }

        short Row { get; set; }

        short Column { get; set; }
    }
}
