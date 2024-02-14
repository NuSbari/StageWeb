using StageWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace StageWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookshelfController : ControllerBase
    {
        private readonly LibraryDb _db;
        public BookshelfController(LibraryDb db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.BookShelves);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.BookShelves.Find(id));
        }

        [HttpPost]
        public IActionResult Post(BookShelf bookshelf)
        {
            _db.BookShelves.Add(bookshelf);
            _db.SaveChanges();
            return Ok(bookshelf);
        }

        [HttpPut]
        public IActionResult Put(BookShelf bookshelf)
        {
            _db.BookShelves.Update(bookshelf);
            _db.SaveChanges();
            return Ok(bookshelf);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var bookshelf = _db.BookShelves.Find(id);
            _db.BookShelves.Remove(bookshelf);
            _db.SaveChanges();
            return Ok();
        }
    }
}