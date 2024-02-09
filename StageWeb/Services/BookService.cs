using StageWeb.Models;

namespace StageWeb.Services
{
    public class BookService
    {
        static List<Book> Books { get; }
        static BookService()
        {
            Books = new List<Book>
            {
                
                new Book { Id = 1, Title = "The Hobbit", IdGenre = 1, IdBookshelf = 1, IsAvailable = true },
                new Book { Id = 2, Title = "The Lord of the Rings", IdGenre = 1, IdBookshelf = 1, IsAvailable = true },
                new Book { Id = 3, Title = "The Silmarillion", IdGenre = 1, IdBookshelf = 1, IsAvailable = true }
                
            };
        }
        public static List<Book> GetAll() => Books;
        public static Book? Get(int id) => Books.FirstOrDefault(p => p.Id == id);

        public static void Add(Book book)
        {
            book.Id = Books.Max(p => p.Id) + 1;
            Books.Add(book);
        }

        public static void Delete(int id)
        {
            var book = Get(id);
            if (book is null)
                return;
            Books.Remove(book);
        }

        public static void Update(Book book)
        {
            var index = Books.FindIndex(p => p.Id == book.Id);
            if (index == -1)
                return;
            Books[index] = book;
        }
    }
}
