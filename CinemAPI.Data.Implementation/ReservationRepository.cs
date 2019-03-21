using System;
using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Data.Implementation.DTOs;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Data.Implementation
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CinemaDbContext db;
        private long id;

        public ReservationRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<IReservation> GetReservedSeats(long projectionId)
        {
            return db.Reservations.Where(x => x.ProjectionId == projectionId);
        }

        public IRoom GetRoomById(long id)
        {
            int roomId = db.Projections.First(x => x.Id == id).RoomId;

            Room room = db.Rooms.FirstOrDefault(x => x.Id == roomId);

            return room;
        }

        public void Insert(IReservationCreation reservation)
        {
            Reservation newReservation = new Reservation(reservation.ProjectionId, reservation.Column, reservation.Row);

            db.Reservations.Add(newReservation);
            db.SaveChanges();
            id = newReservation.Id;
        }

        public IReservationDto CreateReservationTicket(long projectionId, short row, short column)
        {
            Projection currentProjection = db.Projections
                .FirstOrDefault(r => r.Id == projectionId);

            DateTime projectionStartDate = db.Projections
                .FirstOrDefault(p => p.Id == projectionId)
                .StartDate;

            string movieName = db.Movies
                .FirstOrDefault(a => a.Id == currentProjection.MovieId)
                .Name;

            Room room = db.Rooms
                .FirstOrDefault(p => p.Id == currentProjection.RoomId);

            string cinemaName = db.Cinemas
                .FirstOrDefault(n => n.Id == room.CinemaId)
                .Name;

            ReservationDto newReservation = new ReservationDto
            {
                ReservationKey = id,
                ProjectionStartDate = projectionStartDate,
                MovieName = movieName,
                CinemaName = cinemaName,
                RoomNumber = room.Number,
                Row = row,
                Column = column
            };

            currentProjection.AvailableSeatsCount--;
            db.SaveChanges();

            return newReservation;
        }

        public IReservation GetReservationyId(long id)
        {
            Reservation reservation = db.Reservations.FirstOrDefault(x => x.Id == id);

            return reservation;
        }

        public void CancelReservation(IReservation reservation)
        {
            reservation.Canceled = true;
            db.SaveChanges();
        }
    }
}
