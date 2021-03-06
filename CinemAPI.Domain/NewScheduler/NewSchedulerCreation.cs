﻿using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Threading;
using CinemAPI.Data.EF;
using CinemAPI.Data.Implementation.Constants;
using CinemAPI.Domain.Contracts;

namespace CinemAPI.Domain.NewScheduler
{
    public class NewSchedulerCreation : INewScheduler
    {

        public NewSchedulerCreation(CinemaDbContext db)
        {
            Thread cancelReservations = new Thread(InvokeMethod);
            cancelReservations.Start();
        }


        private static void InvokeMethod()
        {
            while (true)
            {
                CancelReservationsTime();
                Thread.Sleep(1000 * 60);
            }
        }

        private static void CancelReservationsTime()
        {
            DateTime now = DateTime.UtcNow.AddMinutes(ActionConstants.MinutesToProjection);
            var logFileName = "CanceledReservationsLog.txt";
            string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);
            using (CinemaDbContext db = new CinemaDbContext())
            {
                var activeReservations = db.Reservations.Where(t => t.Canceled == false).ToArray();
                foreach (var reservation in activeReservations)
                {
                    var startDate = db.Projections.FirstOrDefault(s => s.Id == reservation.ProjectionId);

                    if (startDate.StartDate <= now)
                    {
                        reservation.Canceled = true;
                        string cancelledReservation = 
                            $"Cancellation Time: {now.AddMinutes(-10)} Projection Id: {reservation.ProjectionId} Reservation Id: {reservation.Id}" + Environment.NewLine;
                        File.AppendAllText(destPath, cancelledReservation);
                        startDate.AvailableSeatsCount++;
                        db.Projections.AddOrUpdate(startDate);
                        db.SaveChanges();
                    }
                }

                db.Reservations.AddOrUpdate(activeReservations);
                db.SaveChanges();
            }
        }
    }
}