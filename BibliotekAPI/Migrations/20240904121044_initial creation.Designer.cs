﻿// <auto-generated />
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    [Migration("20240904121044_initial creation")]
    partial class initialcreation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibraryAPI.Models.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("PublishYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libraries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Elena Grey",
                            Description = "A gripping tale of mystery and suspense set in a remote forest.",
                            Genre = "Thriller",
                            IsAvailable = true,
                            PublishYear = 1995,
                            Title = "The Silent Forest"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Richard Deep",
                            Description = "An epic journey to the depths of the ocean where new life forms are discovered.",
                            Genre = "Science Fiction",
                            IsAvailable = true,
                            PublishYear = 2003,
                            Title = "Beneath the Waves"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Lydia Rivers",
                            Description = "A young prince uncovers the secrets of a lost kingdom in a magical world.",
                            Genre = "Fantasy",
                            IsAvailable = true,
                            PublishYear = 2010,
                            Title = "The Forgotten Kingdom"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Mark Henderson",
                            Description = "The harrowing experiences of a soldier during World War II.",
                            Genre = "Historical Fiction",
                            IsAvailable = true,
                            PublishYear = 1987,
                            Title = "Echoes of War"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Jessica Cole",
                            Description = "A detective unravels a web of deceit in a city that never sleeps.",
                            Genre = "Mystery",
                            IsAvailable = true,
                            PublishYear = 2021,
                            Title = "City of Shadows"
                        },
                        new
                        {
                            Id = 6,
                            Author = "David Black",
                            Description = "A haunted house holds terrifying secrets that refuse to stay buried.",
                            Genre = "Horror",
                            IsAvailable = true,
                            PublishYear = 2007,
                            Title = "Whispers in the Dark"
                        },
                        new
                        {
                            Id = 7,
                            Author = "Sophia Wells",
                            Description = "A guide to finding peace and happiness by embracing change.",
                            Genre = "Self-Help",
                            IsAvailable = true,
                            PublishYear = 2015,
                            Title = "The Art of Letting Go"
                        },
                        new
                        {
                            Id = 8,
                            Author = "John Maverick",
                            Description = "A group of explorers ventures into the uncharted wilderness.",
                            Genre = "Adventure",
                            IsAvailable = true,
                            PublishYear = 1992,
                            Title = "The Last Frontier"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Rachel Summers",
                            Description = "A poignant story of love, loss, and the passage of time.",
                            Genre = "Drama",
                            IsAvailable = true,
                            PublishYear = 2018,
                            Title = "Fading Echoes"
                        },
                        new
                        {
                            Id = 10,
                            Author = "Michael Blake",
                            Description = "Two souls find love amidst the chaos of life in the big city.",
                            Genre = "Romance",
                            IsAvailable = true,
                            PublishYear = 2001,
                            Title = "Stardust Dreams"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
