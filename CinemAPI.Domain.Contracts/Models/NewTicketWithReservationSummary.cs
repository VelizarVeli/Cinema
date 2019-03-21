namespace CinemAPI.Domain.Contracts.Models
{
    public class NewTicketWithReservationSummary
    {
        public NewTicketWithReservationSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewTicketWithReservationSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }
    }
}