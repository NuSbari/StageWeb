using StageWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace StageWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Bookcontroller : ControllerBase
    {
        private readonly LibraryDb _db;
        public Bookcontroller(LibraryDb db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Books);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_db.Books.Find(id));
        }

        [HttpPost]
        public IActionResult Post(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
            return Ok(book);
        }

        [HttpPut]
        public IActionResult Put(Book book)
        {
            _db.Books.Update(book);
            _db.SaveChanges();
            return Ok(book);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return Ok();
        }
    }
}