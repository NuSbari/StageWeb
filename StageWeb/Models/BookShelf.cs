namespace StageWeb.Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public string? Code { get; set; }

        public Book? Books { get; set; }
    }
}
