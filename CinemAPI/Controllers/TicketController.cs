using System.Web.Http;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Reservation;
using CinemAPI.Models.Input.Reservation;

namespace CinemAPI.Controllers
{
    public class TicketController : ApiController
    {
        private readonly INewTicketNoRes newTicketNoRes;
        private readonly INewTicketWithReservation newTicketWithReservation;
        private readonly ITicketRepository ticketRepo;
        private readonly IReservationRepository reservationRepo;

        public TicketController(ITicketRepository ticketRepo, INewTicketNoRes newTicketNoRes,
            INewTicketWithReservation newTicketWithReservation, IReservationRepository reservationRepo)
        {
            this.ticketRepo = ticketRepo;
            this.newTicketNoRes = newTicketNoRes;
            this.newTicketWithReservation = newTicketWithReservation;
            this.reservationRepo = reservationRepo;
        }

        [HttpPost]
        public IHttpActionResult BuyTicketNoRes(TicketNoReservationCreationModel model)
        {
            NewTicketSummary summary = newTicketNoRes.New(new Ticket(model.ProjectionIdNumber, model.Row, model.Column));

            if (summary.IsCreated)
            {
                ITicketDto ticket = ticketRepo.CreateTicket(model.ProjectionIdNumber, model.Row, model.Column);

                return Ok(ticket);
            }

            return BadRequest(summary.Message);
        }

        [HttpGet]
        public IHttpActionResult BuyTicketWithReservation(long id)
        {
            IReservation reservation = reservationRepo.GetReservationyId(id);

            NewTicketWithReservationSummary summary = newTicketWithReservation.New(new TicketWithReservation(id, reservation.ProjectionId, 
                reservation.Row, reservation.Column));

            if (summary.IsCreated)
            {
                ITicketDto ticket = ticketRepo.CreateTicket(reservation.ProjectionId, reservation.Row, reservation.Column);

                return Ok(ticket);
            }

            return BadRequest(summary.Message);
        }
    }
}