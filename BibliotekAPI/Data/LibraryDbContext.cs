using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }

        public DbSet<Library> Libraries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Library>().HasData(
                new Library
                {
                    Id = 1,
                    Title = "The Silent Forest",
                    Author = "Elena Grey",
                    PublishYear = 1995,
                    Genre = "Thriller",
                    Description = "A gripping tale of mystery and suspense set in a remote forest.",
                    IsAvailable = true
                },
                new Library
                {
                    Id = 2,
                    Title = "Beneath the Waves",
                    Author = "Richard Deep",
                    PublishYear = 2003,
                    Genre = "Science Fiction",
                    Description = "An epic journey to the depths of the ocean where new life forms are discovered.",
                    IsAvailable = true
                },
                 new Library
                 {
                     Id = 3,
                     Title = "The Forgotten Kingdom",
                     Author = "Lydia Rivers",
                     PublishYear = 2010,
                     Genre = "Fantasy",
                     Description = "A young prince uncovers the secrets of a lost kingdom in a magical world.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 4,
                     Title = "Echoes of War",
                     Author = "Mark Henderson",
                     PublishYear = 1987,
                     Genre = "Historical Fiction",
                     Description = "The harrowing experiences of a soldier during World War II.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 5,
                     Title = "City of Shadows",
                     Author = "Jessica Cole",
                     PublishYear = 2021,
                     Genre = "Mystery",
                     Description = "A detective unravels a web of deceit in a city that never sleeps.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 6,
                     Title = "Whispers in the Dark",
                     Author = "David Black",
                     PublishYear = 2007,
                     Genre = "Horror",
                     Description = "A haunted house holds terrifying secrets that refuse to stay buried.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 7,
                     Title = "The Art of Letting Go",
                     Author = "Sophia Wells",
                     PublishYear = 2015,
                     Genre = "Self-Help",
                     Description = "A guide to finding peace and happiness by embracing change.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 8,
                     Title = "The Last Frontier",
                     Author = "John Maverick",
                     PublishYear = 1992,
                     Genre = "Adventure",
                     Description = "A group of explorers ventures into the uncharted wilderness.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 9,
                     Title = "Fading Echoes",
                     Author = "Rachel Summers",
                     PublishYear = 2018,
                     Genre = "Drama",
                     Description = "A poignant story of love, loss, and the passage of time.",
                     IsAvailable = true
                 },
                 new Library
                 {
                     Id = 10,
                     Title = "Stardust Dreams",
                     Author = "Michael Blake",
                     PublishYear = 2001,
                     Genre = "Romance",
                     Description = "Two souls find love amidst the chaos of life in the big city.",
                     IsAvailable = true
                 }
            );
        }
    }
}
