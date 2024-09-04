using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MaxLength(25)]
        public string Author { get; set; }

        public int PublishYear { get; set; }

        [Required]
        [MaxLength(30)]
        public string Genre { get; set; }

        public string Description { get; set; }
        public bool IsAvailable { get; set; }

    }
}
