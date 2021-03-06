﻿using System;

namespace CinemAPI.Models.Contracts.Projection
{
    public interface IProjectionCreation
    {
        int RoomId { get; }

        int MovieId { get; }

        short AvailableSeatsCount { get; }

        DateTime StartDate { get; }
    }
}