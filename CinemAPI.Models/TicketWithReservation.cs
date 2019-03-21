using System.ComponentModel.DataAnnotations.Schema;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Models
{
    public class TicketWithReservation : ITicketWithReservation, ITicketWithReservationCreation
    {
        public TicketWithReservation()
        {
        }

        public TicketWithReservation(long reservationId, long projectionId, short row, short column)
        {
            this.ReservationId = reservationId;
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        [Index(IsUnique=true)]
        public long Id { get; set; }

        public long ReservationId { get; set; }

        public long ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
