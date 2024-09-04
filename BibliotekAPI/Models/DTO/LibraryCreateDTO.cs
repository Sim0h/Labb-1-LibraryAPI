namespace LibraryAPI.Models.DTO
{
    public class LibraryCreateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublishYear { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
    }
}
