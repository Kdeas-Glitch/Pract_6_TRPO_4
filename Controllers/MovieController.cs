using Microsoft.AspNetCore.Mvc;

using Pract_6_Demin.Models;

using Pract_6_Demin.Service;

using System.Collections.ObjectModel;

namespace Pract_6_Demin.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MovieController : ControllerBase
    {

        

        [HttpGet]
        public IActionResult GetAll([FromQuery] string? Genre, [FromQuery] int? minYear)
        {
            try
            {
                MovieService.GetAllMovies();

                var movies = MovieService.GetWithQuery(Genre, minYear);

                if(movies.Count>0)
                    return Ok(movies);
                else
                    return NoContent();
            }
            catch
            {
                return NoContent();
            }
        }



        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                MovieService.GetAllMovies();

                var m = MovieService.Get(id);

                if(m==null)
                    return NotFound();

                return Ok(m);
            }
            catch
            {
                return NotFound();
            }
        }



        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            MovieService.GetAllMovies();

            if (MovieService.Add(movie))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        [HttpPut("{id:int}")]
        public IActionResult Put(int id,Movie movie)
        {
            MovieService.GetAllMovies();

            if (MovieService.Change(id,movie))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }




        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id,FMovie mov)
        {
            MovieService.GetAllMovies();

            if (MovieService.ChangeS(id, mov))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }




        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            MovieService.GetAllMovies();

            if (MovieService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }



    }
}
