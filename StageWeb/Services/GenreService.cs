using StageWeb.Models;

namespace StageWeb.Services
{
    public class GenreService
    {
        static List<Genre> Genres { get; }
        static GenreService()
        {
            Genres = new List<Genre>
            {
                new Genre { Id = 1, Description = "Fantasy" },
                new Genre { Id = 2, Description = "Science Fiction" },
                new Genre { Id = 3, Description = "Mystery" }
            };
        }
        public static List<Genre> GetAll() => Genres;

        public static Genre? Get(int id) => Genres.FirstOrDefault(p => p.Id == id);

        public static void Add(Genre genre)
        {
            genre.Id = Genres.Max(p => p.Id) + 1;
            Genres.Add(genre);
        }

        public static void Delete(int id)
        {
            var genre = Get(id);
            if (genre is null)
                return;
            Genres.Remove(genre);
        }

        public static void Update(Genre genre)
        {
            var index = Genres.FindIndex(p => p.Id == genre.Id);
            if (index == -1)
                return;
            Genres[index] = genre;
        }
    }
}
