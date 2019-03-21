namespace CinemAPI.Domain.Contracts.Models
{
    public class NewReservationSummary
    {
        public NewReservationSummary(bool isCreated)
        {
            this.IsCreated = isCreated;
        }

        public NewReservationSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool IsCreated { get; set; }
    }
}