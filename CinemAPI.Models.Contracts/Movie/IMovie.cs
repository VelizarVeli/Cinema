namespace CinemAPI.Models.Contracts.Movie
{
    public interface IMovie
    {
        int Id { get; set; }

        string Name { get; set; }

        short DurationMinutes { get; set; }
    }
}