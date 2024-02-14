using StageWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StageWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : ControllerBase
    {
        private readonly LibraryDb _db;
        public GenreController(LibraryDb db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Genres);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.Genres.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Genre genre)
        {
            _db.Genres.Add(genre);
            _db.SaveChanges();
            return Ok(genre);
        }

        [HttpPut]
        public IActionResult Put(Genre genre)
        {
            _db.Genres.Update(genre);
            _db.SaveChanges();
            return Ok(genre);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _db.Genres.Find(id);
            _db.Genres.Remove(genre);
            _db.SaveChanges();
            return Ok();
        }
    }
}
