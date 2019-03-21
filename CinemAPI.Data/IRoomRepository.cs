using CinemAPI.Models.Contracts.Room;

namespace CinemAPI.Data
{
    public interface IRoomRepository
    {
        IRoom GetById(int id);

        IRoom GetByCinemaAndNumber(int cinemaId, int number);

        void Insert(IRoomCreation room);
    }
}