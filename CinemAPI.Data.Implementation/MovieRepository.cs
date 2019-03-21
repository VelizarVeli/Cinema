using CinemAPI.Data.EF;
using CinemAPI.Models;
using CinemAPI.Models.Contracts.Movie;
using System.Linq;

namespace CinemAPI.Data.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private readonly CinemaDbContext db;

        public MovieRepository(CinemaDbContext db)
        {
            this.db = db;
        }

        public IMovie GetById(int movieId)
        {
            return db.Movies.FirstOrDefault(x => x.Id == movieId);
        }

        public IMovie GetByNameAndDuration(string name, short duration)
        {
            return db.Movies.FirstOrDefault(x => x.Name == name &&
                                                 x.DurationMinutes == duration);
        }

        public void Insert(IMovieCreation movie)
        {
            Movie newMovie = new Movie(movie.Name, movie.DurationMinutes);

            db.Movies.Add(newMovie);
            db.SaveChanges();
        }
    }
}