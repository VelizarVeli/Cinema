using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CinemAPI.Models.Contracts.Reservation;

namespace CinemAPI.Models
{
    public class Reservation : IReservation, IReservationCreation
    {
        public Reservation()
        {
        }

        public Reservation(long projectionId, short row, short column)
        {
            this.ProjectionId = projectionId;
            this.Row = row;
            this.Column = column;
        }

        [Key]
        [Index(IsUnique=true)]
        public long Id { get; set; }

        public long ProjectionId { get; set; }
        public virtual Projection Projection { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }

        public bool Canceled { get; set; } = false;
    }
}
