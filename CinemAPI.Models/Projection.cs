using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;

namespace CinemAPI.Models
{
    public class Projection : IProjection, IProjectionCreation
    {
        public Projection()
        {
            this.Reservations = new List<Reservation>();
        }

        public Projection(int movieId, int roomId, DateTime startdate, short availableSeatsCount)
        {
            this.MovieId = movieId;
            this.RoomId = roomId;
            this.StartDate = startdate;
            this.AvailableSeatsCount = availableSeatsCount;
        }

        public long Id { get; set; }

        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        public short AvailableSeatsCount { get; set; }

        public DateTime StartDate { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}