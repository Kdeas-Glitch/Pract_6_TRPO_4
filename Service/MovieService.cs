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
            M.Id = Mov.Count + 1;


            Mov.Add(M);

            M.Id = 0;

            _db.Movies.Add(M);
            _db.SaveChanges();

            return Mov[M.Id-1].Id != 0;
        }

        static public bool Change(int id,Movie movie)
        {
            if (id > Mov.Count())
                return false;
            if (movie.Title.IsNullOrEmpty())
                return false;
            if (movie.Genre.IsNullOrEmpty())
                return false;
            if (movie.DurationMinutes == 0)
                return false;
            if (movie.ReleaseYear <= 0)
                return false;
            if (movie.Id != id)
                return false;


            var movie1 = _db.Movies.FirstOrDefault(item=>item.Id==id);

            if (movie1 == null)
                return false;

            movie1.Title = movie.Title;
            movie1.Genre = movie.Genre;
            movie1.DurationMinutes = movie.DurationMinutes;
            movie1.ReleaseYear = movie.ReleaseYear;
            movie1.IsAvailable = movie.IsAvailable;


            Mov[id-1] = movie;

            _db.SaveChanges();

            return true;


        }


        static public bool Delete(int id)
        {
            try
            {
                _db.Movies.RemoveRange(Mov[id - 1]);
                _db.SaveChanges();
                Mov.Remove(Mov[id - 1]);

                return true;
            }
            catch
            {
                return false;
            }
           
        }

        static public bool ChangeS(int id,FMovie movie)
        {
            _db.Movies.FirstOrDefault(item => item.Id == id);



            return false;
        }
    }
}
