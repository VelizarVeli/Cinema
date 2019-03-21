using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class MovieModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Movie> movieModel = modelBuilder.Entity<Movie>();
            movieModel.HasKey(model => model.Id);
            movieModel.Property(model => model.Name).IsRequired();
            movieModel.Property(model => model.DurationMinutes).IsRequired();
        }
    }
}
