using System;
using System.Collections.Generic;
using System.Linq;
using CinemAPI.Data.EF;
using CinemAPI.Data.Implementation.DTOs;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Contracts.Ticket;

namespace CinemAPI.Data.Implementation
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CinemaDbContext db;
        private long id;

        public TicketRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public void Insert(ITicketCreation ticket)
        {
            Ticket newTicket = new Ticket(ticket.ProjectionId, ticket.Row, ticket.Column);

            db.Tickets.Add(newTicket);
            db.SaveChanges();
            id = newTicket.Id;
        }

        public IEnumerable<ITicket> GetPurchasedSeats(long projectionId)
        {
            return db.Tickets.Where(x => x.ProjectionId == projectionId);
        }

        public IEnumerable<IReservation> GetReservedSeats(long projectionId)
        {
            return db.Reservations.Where(x => x.ProjectionId == projectionId);
        }

        public ITicketDto CreateTicket(long projectionId, short row, short column)
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

            TicketDto newReservation = new TicketDto
            {
                TicketKey = id,
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
    }
}
