namespace CinemAPI.Domain.Contracts.Models
{
    public class NewTicketSummary
    {
        public NewTicketSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewTicketSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }
    }
}