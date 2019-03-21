namespace CinemAPI.Models.Contracts.Room
{
    public interface IRoomCreation
    {
        int Number { get; }

        short SeatsPerRow { get; }

        short Rows { get; }

        int CinemaId { get; }
    }
}