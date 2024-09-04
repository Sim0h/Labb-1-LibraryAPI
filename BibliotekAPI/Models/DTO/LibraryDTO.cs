using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTO
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
