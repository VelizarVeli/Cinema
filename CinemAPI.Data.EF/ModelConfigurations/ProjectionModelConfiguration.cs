using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class ProjectionModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Projection> projectionModel = modelBuilder.Entity<Projection>();
            projectionModel.HasKey(model => model.Id);
            projectionModel.Property(model => model.MovieId).IsRequired();
            projectionModel.Property(model => model.RoomId).IsRequired();
            projectionModel.Property(model => model.StartDate).IsRequired();
            projectionModel.Property(model => model.AvailableSeatsCount).IsRequired();
            //projectionModel.HasMany(r=>r.).Withone
        }
    }
}
