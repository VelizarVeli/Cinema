using CinemAPI.Models.Contracts.Room;
using System.Collections.Generic;

namespace CinemAPI.Models
{
    public class Room : IRoom, IRoomCreation
    {
        public Room()
        {
            this.Projections = new List<Projection>();
        }

        public Room(int number, short seatsPerRow, short rows, int cinemaId)
            : this()
        {
            this.Number = number;
            this.SeatsPerRow = seatsPerRow;
            this.Rows = rows;
            this.CinemaId = cinemaId;
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public short SeatsPerRow { get; set; }

        public short Rows { get; set; }

        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        public virtual ICollection<Projection> Projections { get; set; }
    }
}