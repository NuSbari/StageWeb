using StageWeb.Models;
using StageWeb.Services;
using Microsoft.AspNetCore.Mvc;
namespace StageWeb.Controllers
{
    [ApiController]
    [Route("Book")]
    public class Bookcontroller : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAll() => BookService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookService.Get(id);
            if (book is null)
                return NotFound();
            return book;
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            BookService.Add(book);
            return CreatedAtAction(nameof(Add), new { id = book.Id }, book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookService.Get(id);
            if (book is null)
                return NotFound();
            BookService.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id)
                return BadRequest();
            var existingBook = BookService.Get(id);
            if (existingBook is null)
                return NotFound();
            BookService.Update(book);
            return NoContent();
        }
    }
}