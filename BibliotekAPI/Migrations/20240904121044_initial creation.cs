using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialcreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    PublishYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Libraries",
                columns: new[] { "Id", "Author", "Description", "Genre", "IsAvailable", "PublishYear", "Title" },
                values: new object[,]
                {
                    { 1, "Elena Grey", "A gripping tale of mystery and suspense set in a remote forest.", "Thriller", true, 1995, "The Silent Forest" },
                    { 2, "Richard Deep", "An epic journey to the depths of the ocean where new life forms are discovered.", "Science Fiction", true, 2003, "Beneath the Waves" },
                    { 3, "Lydia Rivers", "A young prince uncovers the secrets of a lost kingdom in a magical world.", "Fantasy", true, 2010, "The Forgotten Kingdom" },
                    { 4, "Mark Henderson", "The harrowing experiences of a soldier during World War II.", "Historical Fiction", true, 1987, "Echoes of War" },
                    { 5, "Jessica Cole", "A detective unravels a web of deceit in a city that never sleeps.", "Mystery", true, 2021, "City of Shadows" },
                    { 6, "David Black", "A haunted house holds terrifying secrets that refuse to stay buried.", "Horror", true, 2007, "Whispers in the Dark" },
                    { 7, "Sophia Wells", "A guide to finding peace and happiness by embracing change.", "Self-Help", true, 2015, "The Art of Letting Go" },
                    { 8, "John Maverick", "A group of explorers ventures into the uncharted wilderness.", "Adventure", true, 1992, "The Last Frontier" },
                    { 9, "Rachel Summers", "A poignant story of love, loss, and the passage of time.", "Drama", true, 2018, "Fading Echoes" },
                    { 10, "Michael Blake", "Two souls find love amidst the chaos of life in the big city.", "Romance", true, 2001, "Stardust Dreams" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libraries");
        }
    }
}
