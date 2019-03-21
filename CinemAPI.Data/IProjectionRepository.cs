using CinemAPI.Models.Contracts.Projection;
using System;
using System.Collections.Generic;

namespace CinemAPI.Data
{
    public interface IProjectionRepository
    {
        IProjection Get(int movieId, int roomId, DateTime startDate, int availableSeatsCount);

        void Insert(IProjectionCreation projection);

        IProjection GetById(long projectionId);

        IEnumerable<IProjection> GetActiveProjections(int roomId);
    }
}