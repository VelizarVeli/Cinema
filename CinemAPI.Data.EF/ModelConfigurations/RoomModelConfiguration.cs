using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class RoomModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Room> roomModel = modelBuilder.Entity<Room>();
            roomModel.HasKey(model => model.Id);
            roomModel.Property(model => model.Number).IsRequired();
            roomModel.Property(model => model.Rows).IsRequired();
            roomModel.Property(model => model.SeatsPerRow).IsRequired();
            roomModel.Property(model => model.CinemaId).IsRequired();
        }
    }
}
