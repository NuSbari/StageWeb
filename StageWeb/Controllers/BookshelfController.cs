using StageWeb.Models;
using StageWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace StageWeb.Controllers
{
    [ApiController]
    [Route("Bookshelf")]
    public class BookshelfController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<BookShelf>> GetAll() => BookShelfServices.GetAll();

        [HttpGet("{id}")]
        public ActionResult<BookShelf> Get(int id)
        {
            var bookShelf = BookShelfServices.Get(id);
            if (bookShelf is null)
                return NotFound();
            return bookShelf;
        }

        [HttpPost]
        public IActionResult Add(BookShelf bookShelf)
        {
            BookShelfServices.Add(bookShelf);
            return CreatedAtAction(nameof(Add), new { id = bookShelf.Id }, bookShelf);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var bookShelf = BookShelfServices.Get(id);
            if (bookShelf is null)
                return NotFound();
            BookShelfServices.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, BookShelf bookShelf)
        {
            if (id != bookShelf.Id)
                return BadRequest();
            var existingBookShelf = BookShelfServices.Get(id);
            if (existingBookShelf is null)
                return NotFound();
            BookShelfServices.Update(bookShelf);
            return NoContent();
        }
    }
}
