namespace CinemAPI.Models.Input.Reservation
{
    public class TicketNoReservationCreationModel
    {
        public long ProjectionIdNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}