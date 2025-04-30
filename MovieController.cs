using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace jurnal10_103022330167
{
	[ApiController]
	[Route("api/[controller]")]
	public class MovieController : ControllerBase
	{
		private static List<Movie> daftarMovie = new List<Movie>
		{
			new Movie("The Shawshank Redemption", "Frank Darabont", new List<string>{"Tim Robbins, Morgan Freeman, Bob Gunton" }, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
			new Movie("The Godfather", "Franciss Ford Coppola", new List<string>{"Marlon Brando, AI Pacino, James Caan" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
			new Movie("The Dark Knight", "Christopher Nolan", new List<string>{"Christian Bale, Heath Ledger, Aaron Eckhart" }, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.")
		};

		[HttpGet]
		public ActionResult<List<Movie>> Getmovie()
		{
			return daftarMovie;
		}

		[HttpGet("{index}")]
        public ActionResult<Movie> GetmovieByIndex(int index)
        {
            if(index < 0 || index >= daftarMovie.Count)
			{
				return NotFound();
			}
			return daftarMovie[index];
        }

        [HttpPost]
        public ActionResult<List<Movie>> Postmovie([FromBody]Movie MovieBaru)
        {
            daftarMovie.Add(MovieBaru);
			return daftarMovie;
        }

		[HttpDelete("{index}")]
        public ActionResult<List<Movie>> DeleteMovie(int index)
        {
            if (index < 0 || index >= daftarMovie.Count)
            {
                return NotFound();
            }
            daftarMovie.RemoveAt(index);
            return daftarMovie;
        }
    }
}
