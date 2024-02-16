using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StageWeb.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int IdGenre { get; set; }
        public int IdBookshelf { get; set; }
        public bool IsAvailable { get; set; }

        // Proprietà di navigazione
        [ForeignKey("IdGenre")]
        public Genre Genre { get; set; }
        [ForeignKey("IdBookshelf")]
        public BookShelf BookShelf { get; set; }
        
    }
}
    