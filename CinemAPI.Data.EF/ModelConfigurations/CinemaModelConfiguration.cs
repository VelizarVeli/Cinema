using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class CinemaModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Cinema> cinemaModel = modelBuilder.Entity<Cinema>();
            cinemaModel.HasKey(model => model.Id);
            cinemaModel.Property(model => model.Name).IsRequired();
            cinemaModel.Property(model => model.Address).IsRequired();
        }
    }
}
