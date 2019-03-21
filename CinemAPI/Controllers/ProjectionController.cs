using System;
using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models;
using CinemAPI.Models.Input.Projection;
using System.Web.Http;
using CinemAPI.Data;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Controllers
{
    public class ProjectionController : ApiController
    {
        private readonly INewProjection newProj;
        private readonly IProjectionRepository projRepo;

        public ProjectionController(INewProjection newProj, IProjectionRepository projRepo)
        {
            this.newProj = newProj;
            this.projRepo = projRepo;
        }

        [HttpPost]
        public IHttpActionResult Index(ProjectionCreationModel model)
        {
            NewProjectionSummary summary = newProj.New(new Projection(model.MovieId, model.RoomId, model.StartDate, 
                model.AvailableSeatsCount));

            if (summary.IsCreated)
            {
                return Ok();
            }
            else
            {
                return BadRequest(summary.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetSeatsCount(long id)
        {
            IProjection projection = projRepo.GetById(id);

            DateTime timeNow = DateTime.UtcNow;

            if (timeNow < projection.StartDate)
            {
                return Ok(projection.AvailableSeatsCount);
            }

            return BadRequest("You can't get the seats count as the movie has already started or finished");
        }
    }
}