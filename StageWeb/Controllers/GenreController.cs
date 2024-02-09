using StageWeb.Models;
using StageWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace StageWeb.Controllers
{
    [ApiController]
    [Route("Genre")]
    public class GenreController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Genre>> GetAll() => GenreService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Genre> Get(int id)
        {
            var genre = GenreService.Get(id);
            if (genre is null)
                return NotFound();
            return genre;
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            GenreService.Add(genre);
            return CreatedAtAction(nameof(Add), new { id = genre.Id }, genre);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = GenreService.Get(id);
            if (genre is null)
                return NotFound();
            GenreService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Genre genre)
        {
            if (id != genre.Id)
                return BadRequest();
            var existingGenre = GenreService.Get(id);
            if (existingGenre is null)
                return NotFound();
            GenreService.Update(genre);
            return NoContent();
        }
    }
}
