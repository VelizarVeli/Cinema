using System;

namespace CinemAPI.Data.Implementation.DTOs
{
    public class ReservationDto : IReservationDto
    {
        public long ReservationKey { get; set; }

        public DateTime ProjectionStartDate { get; set; }

        public string MovieName { get; set; }

        public string CinemaName { get; set; }

        public int RoomNumber { get; set; }

        public short Row { get; set; }

        public short Column { get; set; }
    }
}
