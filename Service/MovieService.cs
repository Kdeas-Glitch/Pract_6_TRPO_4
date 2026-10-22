using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

using Pract_6_Demin.Models;

namespace Pract_6_Demin.Service
{
    static public class MovieService
    {
        static private readonly WebApiDatabaseContext _db = DBService.Instance.Context;

        static public List<Movie> Mov { get; set; } = new();

        static public void GetAllMovies()
        {

            Mov.Clear();

            foreach(var m in _db.Movies)
            {
                Mov.Add(m);
            }
        }

        static public Movie Get(int id)
        {
            var movie = _db.Movies.FirstOrDefault(item => item.Id == id);

            if (movie == null)
                return null;

            return movie;
        }

        static public List<Movie> GetWithQuery(string? genre, int? minYear)
        {
            List<Movie> movies = _db.Movies.ToList();

            List<Movie> TrueMovies=new();

            if (genre != null && minYear != null)
            {
                foreach(var movie in movies)
                {
                    if (movie.Genre == genre && movie.ReleaseYear >= minYear)
                    {
                        TrueMovies.Add(movie);
                    }
                }
            }
            if (genre == null && minYear != null)
            {
                foreach (var movie in movies)
                {
                    if (movie.ReleaseYear >= minYear)
                    {
                        TrueMovies.Add(movie);
                    }
                }
            }
            if (genre != null && minYear == null)
            {
                foreach (var movie in movies)
                {
                    if (movie.Genre == genre)
                    {
                        TrueMovies.Add(movie);
                    }
                }
            }

            if (genre == null && minYear == null)
                return movies;

            return TrueMovies;

        }

        static public bool Add(Movie M)
        {
            if (M.Title.IsNullOrEmpty())
                return false;
            if (M.Genre.IsNullOrEmpty())
                return false;
            if (M.DurationMinutes == 0)
                return false;
            if (M.ReleaseYear <= 0)
                return false;
            M.Id = 0;



            _db.Movies.Add(M);


            _db.SaveChanges();

            return true;
        }

        static public bool Add(List<Movie> movie)
        {
            try
            {
                foreach (var M in movie)
                {
                    if (M.Title.IsNullOrEmpty())
                        return false;
                    if (M.Genre.IsNullOrEmpty())
                        return false;
                    if (M.DurationMinutes == 0)
                        return false;
                    if (M.ReleaseYear <= 0)
                        return false;
                    M.Id = Mov.Count + 1;


                    Mov.Add(M);

                    M.Id = 0;
                    _db.Movies.Add(M);
                }
            }
            catch
            {
                return false;
            }

            _db.SaveChanges();

            return true;
        }

        static public bool Change(int id,Movie movie)
        {
            var movie1 = _db.Movies.FirstOrDefault(item=>item.Id==id);

            if (movie1 == null)
                return false;

            if (movie.Title.IsNullOrEmpty())
                return false;
            if (movie.Genre.IsNullOrEmpty())
                return false;
            if (movie.DurationMinutes <= 0)
                return false;
            if (movie.ReleaseYear <= 0)
                return false;



            if (movie1 == null)
                return false;

            movie1.Title = movie.Title;
            movie1.Genre = movie.Genre;
            movie1.DurationMinutes = movie.DurationMinutes;
            movie1.ReleaseYear = movie.ReleaseYear;
            movie1.IsAvailable = movie.IsAvailable;


            _db.SaveChanges();

            return true;


        }


        static public bool Delete(int id)
        {
            try
            {
                var movie1 = _db.Movies.FirstOrDefault(item => item.Id == id);

                if (movie1 == null)
                    return false;

                _db.Movies.RemoveRange(movie1);
                _db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        static public bool ChangeS(int id,FMovie movie)
        {
            var movie1 = _db.Movies.FirstOrDefault(item => item.Id == id);
            if (movie1 == null)
                return false;

            if (!movie.Title.IsNullOrEmpty())
                movie1.Title = movie.Title;

            if (!movie.Genre.IsNullOrEmpty())
                movie1.Genre = movie.Genre;

            if (movie.DurationMinutes != null&&movie.DurationMinutes>0)
                movie1.DurationMinutes = (int)movie.DurationMinutes;

            if (movie.ReleaseYear != null&&movie.ReleaseYear>0)
                movie1.ReleaseYear = (int)movie.ReleaseYear;

            if (movie.IsAvailable != null)
                movie1.IsAvailable = (bool)movie.IsAvailable;

            _db.SaveChanges();

            return true;
        }
    }
}
