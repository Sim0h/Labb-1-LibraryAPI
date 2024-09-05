using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTO
{
    public class LibraryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Publish year is required")]
        public int PublishYear { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        public string Genre { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public bool IsAvailable { get; set; }
    }
}
