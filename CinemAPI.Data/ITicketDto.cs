﻿using System;

namespace CinemAPI.Data
{
    public interface ITicketDto
    {
        long TicketKey { get; set; }

        DateTime ProjectionStartDate { get; set; }

        string MovieName { get; set; }

        string CinemaName { get; set; }

        int RoomNumber { get; set; }

        short Row { get; set; }

        short Column { get; set; }
    }
}
