using CinemAPI.Data.EF.ModelConfigurations;
using CinemAPI.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace CinemAPI.Data.EF
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
            : base("CinemaDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CinemaDbContext, MigrationConfiguration>());
        }

        public virtual IDbSet<Cinema> Cinemas { get; set; }

        public virtual IDbSet<Room> Rooms { get; set; }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<Projection> Projections { get; set; }

        public virtual IDbSet<Reservation> Reservations { get; set; }

        public virtual IDbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            IEnumerable<IModelConfiguration> modelConfigurations = new List<IModelConfiguration>()
            {
                new CinemaModelConfiguration(),
                new MovieModelConfiguration(),
                new ProjectionModelConfiguration(),
                new RoomModelConfiguration(),
                new ReservationModelConfiguration(),
                new TicketModelConfiguration()
            };

            foreach (IModelConfiguration configurationModel in modelConfigurations)
            {
                configurationModel.Configure(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}