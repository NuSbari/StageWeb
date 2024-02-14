using Microsoft.EntityFrameworkCore;

namespace StageWeb.Models
{
    public class LibraryDb : DbContext
    {
        public LibraryDb(DbContextOptions<LibraryDb> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookShelf> BookShelves { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
