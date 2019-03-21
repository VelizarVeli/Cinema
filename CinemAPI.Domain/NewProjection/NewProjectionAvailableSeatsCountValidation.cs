using CinemAPI.Domain.Contracts;
using CinemAPI.Domain.Contracts.Models;
using CinemAPI.Models.Contracts.Projection;

namespace CinemAPI.Domain.NewProjection
{
   public class NewProjectionAvailableSeatsCountValidation : INewProjection
    {
        private readonly INewProjection newProj;

        public NewProjectionAvailableSeatsCountValidation(INewProjection newProj)
        {
            this.newProj = newProj;
        }

        public NewProjectionSummary New(IProjectionCreation proj)
        {

            if (proj.AvailableSeatsCount < 0)
            {
                return new NewProjectionSummary(false, "Available seats can not be less than zero!");
            }

            return newProj.New(proj);
        }
    }
}
