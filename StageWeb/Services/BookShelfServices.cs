using StageWeb.Models;

namespace StageWeb.Services
{
    public class BookShelfServices
    {
        static List<BookShelf> BookShelves { get; }
        static BookShelfServices()
        {
            BookShelves = new List<BookShelf>
            {
                new BookShelf { Id = 1, Code = "A01" },
                new BookShelf { Id = 2, Code = "A02" },
                new BookShelf { Id = 3, Code = "A03"  }
            };
        }
        public static List<BookShelf> GetAll() => BookShelves;

        public static BookShelf? Get(int id) => BookShelves.FirstOrDefault(p => p.Id == id);

        public static void Add(BookShelf bookShelf)
        {
            bookShelf.Id = BookShelves.Max(p => p.Id) + 1;
            BookShelves.Add(bookShelf);
        }

        public static void Delete(int id)
        {
            var bookShelf = Get(id);
            if (bookShelf is null)
                return;
            BookShelves.Remove(bookShelf);
        }

        public static void Update(BookShelf bookShelf)
        {
            var index = BookShelves.FindIndex(p => p.Id == bookShelf.Id);
            if (index == -1)
                return;
            BookShelves[index] = bookShelf;
        }
    }
}
