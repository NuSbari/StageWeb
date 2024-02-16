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
             var books = _db.Books
                 .Include(b => b.Genre)
                 .Include(b => b.BookShelf)
                 .ToList();
             return Ok(books);
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
            var genre = _db.Genres.Find(book.IdGenre);
            var bookshelf = _db.BookShelves.Find(book.IdBookshelf);

            if (genre == null || bookshelf == null)
            {
                return NotFound("Genere o libreria non trovati");
            }

            book.Genre = genre;
            book.BookShelf = bookshelf;

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
            if (book != null)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound("Nessun Libro Trovato");
            }
        }


        /*[HttpGet]
        [Route("search")]
        public IActionResult Search(string title)
        {
            return Ok(_db.Books.FromSqlRaw("SELECT * FROM Books WHERE Title LIKE '%' || {0} || '%'", title));
        }
        public void AddBook(Book book, int genreId, int libraryId)
        {
            // Verifica se l'ID del genere esiste già
            var genreExists = _db.Genres.Any(g => g.Id == genreId);
            if (!genreExists)
            {
                throw new Exception("Il genere con l'ID specificato non esiste.");
            }

            // Verifica se l'ID della libreria esiste già
            var libraryExists = _db.BookShelves.Any(l => l.Id == libraryId);
            if (!libraryExists)
            {
                throw new Exception("La libreria con l'ID specificato non esiste.");
            }

            // Assegna gli ID del genere e della libreria al libro
            book.IdGenre = genreId;
            book.IdBookshelf = libraryId;

            // Aggiungi il libro al database
            _db.Books.Add(book);
            _db.SaveChanges();
        }*/
    }
}