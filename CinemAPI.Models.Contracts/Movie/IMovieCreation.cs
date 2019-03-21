namespace CinemAPI.Models.Contracts.Movie
{
    public interface IMovieCreation
    {
        string Name { get; }

        short DurationMinutes { get; }
    }
}