using System.ComponentModel.DataAnnotations.Schema;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Models
{
    public class Ticket : ITicket, ITicketCreation
    {
        public Ticket()
        {
        }

        public Ticket(long projectionId, short row, short column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        [Index(IsUnique=true)]
        public long Id { get; set; }

        public long ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
