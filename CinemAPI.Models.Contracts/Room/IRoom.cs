namespace CinemAPI.Models.Contracts.Room
{
    public interface IRoom
    {
       int Id { get; }

       int CinemaId { get; }

       int Number { get; }

       short SeatsPerRow { get; }

       short Rows { get; }
    }
}