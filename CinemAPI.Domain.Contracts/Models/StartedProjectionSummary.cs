
namespace CinemAPI.Domain.Contracts.Models
{
    public class StartedProjectionSummary
    {
        public StartedProjectionSummary(bool hasStarted)
        {
            this.HasStarted = hasStarted;
        }

        public StartedProjectionSummary(bool status, string msg)
            : this(status)
        {
            this.Message = msg;
        }

        public string Message { get; set; }

        public bool HasStarted { get; set; }
    }
}
