﻿using System.Web.Http;
using CinemAPI.Data;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Reservation;

namespace CinemAPI.Controllers
{
    public class BuyTicketWithResController : ApiController
    {
        private readonly INewReservation newRes;
        private readonly IReservationRepository reservationRepo;

        public BuyTicketWithResController(IReservationRepository reservationRepo, INewReservation newRes)
        {
            this.reservationRepo = reservationRepo;
            this.newRes = newRes;
        }

        [HttpPost]
        public IHttpActionResult Index(ReservationCreationModel model)
        {
            NewReservationSummary summary = newRes.New(new Reservation(model.ProjectionIdNumber, model.Row, model.Column));

            if (summary.IsCreated)
            {
                IReservationDto reservation = reservationRepo.CreateReservationTicket(model.ProjectionIdNumber, model.Column, model.Row);

                return Ok(reservation);
            }

            return BadRequest(summary.Message);
        }
    }
}