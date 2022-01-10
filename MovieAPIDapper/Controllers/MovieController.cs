using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPIDapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : Controller
    {
        MovieDAL md = new MovieDAL();

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return md.GetAllMovies();
        }

        [HttpGet("GetGenres/{genre}")]
        public List<Movie> GetByGenre(string genre)
        {
            List<Movie> movies = md.GetAllMovies();
            List<Movie> filteredMovies = new List<Movie>();
            foreach (var movie in movies)
            {
                if (movie.Genre.Trim().ToLower() == genre.Trim().ToLower())
                {
                    filteredMovies.Add(movie);
                }
            }
            return filteredMovies;
        }

        [HttpGet("Random")]
        public Movie GetRandomMovie()
        {
            return md.GetRandomMovie();
        }

        [HttpGet("RandomGenre/{genre}")]
        public Movie GetRandomByGenre(string genre)
        {
            return md.GetRandomGenre(genre);
        }

        [HttpGet("Randomtitle/{title}")]
        public Movie GetRandomTitle(string title)
        {
            return md.GetRandomTitle(title);
        }
    }    
}
