using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using CinemAPI.Models;

namespace CinemAPI.Data.EF.ModelConfigurations
{
    internal sealed class TicketModelConfiguration : IModelConfiguration
    {
        public void Configure(DbModelBuilder modelBuilder)
        {
            EntityTypeConfiguration<Ticket> ticketModel = modelBuilder.Entity<Ticket>();
            ticketModel.HasKey(model => model.Id);
            ticketModel.Property(model => model.ProjectionId).IsRequired();
            ticketModel.Property(model => model.Row).IsRequired();
            ticketModel.Property(model => model.Column).IsRequired();
        }
    }
}
