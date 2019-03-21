namespace CinemAPI.Models.Contracts.Cinema
{
    public interface ICinema
    {
        int Id { get; }

        string Name { get; }

        string Address { get; }
    }
}