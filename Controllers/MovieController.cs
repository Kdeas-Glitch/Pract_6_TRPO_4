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
        public IActionResult GetAll()
        {
            MovieService.GetAllMovies();
            return Ok(MovieService.Mov);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAll(int id)
        {
            MovieService.GetAllMovies();

            return Ok(MovieService.Mov[id-1]);
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


        [HttpPut]
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


        [HttpPatch]
        public IActionResult Patch(int id,FMovie mov)
        {
            MovieService.ChangeS(id, mov);

            return Ok();
        }


        [HttpDelete("{id:int}")]
        public IActionResult Delet(int id)
        {
            MovieService.GetAllMovies();

            if (MovieService.Delete(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }



    }
}
