using CinemAPI.Data;
using CinemAPI.Data.EF;
using CinemAPI.Data.Implementation;
using SimpleInjector;
using SimpleInjector.Packaging;

namespace CinemAPI.IoCContainer
{
    public class DataPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<ICinemaRepository, CinemaRepository>(Lifestyle.Scoped);
            container.Register<IRoomRepository, RoomRepository>(Lifestyle.Scoped);
            container.Register<IMovieRepository, MovieRepository>(Lifestyle.Scoped);
            container.Register<IProjectionRepository, ProjectionRepository>(Lifestyle.Scoped);
            container.Register<IReservationRepository, ReservationRepository>(Lifestyle.Scoped);
            container.Register<ITicketRepository, TicketRepository>(Lifestyle.Scoped);

            container.Register<CinemaDbContext>(Lifestyle.Scoped);
        }
    }
}