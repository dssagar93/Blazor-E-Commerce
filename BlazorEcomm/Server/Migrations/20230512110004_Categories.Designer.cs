﻿// <auto-generated />
using BlazorEcomm.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcomm.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230512110004_Categories")]
    partial class Categories
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorEcomm.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Books",
                            Url = "books"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Movies",
                            Url = "movies"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Video Games",
                            Url = "video-games"
                        });
                });

            modelBuilder.Entity("BlazorEcomm.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Batman Begins is a 2005 superhero film directed by Christopher Nolan and written by Nolan and David S. Goyer. The film is based on the DC Comics character Batman, it stars Christian Bale as Bruce Wayne / Batman, with Michael Caine, Liam Neeson, Katie Holmes, Gary Oldman, Cillian Murphy, Tom Wilkinson, Rutger Hauer, Ken Watanabe, and Morgan Freeman in supporting roles. The film reboots the Batman film series, telling the origin story of Bruce Wayne from the death of his parents to his journey to become Batman and his fight to stop Ra's al Ghul and the Scarecrow from plunging Gotham City into chaos.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/af/Batman_Begins_Poster.jpg/220px-Batman_Begins_Poster.jpg",
                            Price = 9.99m,
                            Title = "Batman Begins"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "Ready Player One is a 2018 American science fiction film based on Ernest Cline's novel of the same name. Directed by Steven Spielberg from a screenplay by Zak Penn and Cline, it stars Tye Sheridan, Olivia Cooke, Ben Mendelsohn, Lena Waithe, T.J. Miller, Simon Pegg, and Mark Rylance. The film is set in 2045, where much of humanity uses the OASIS, a virtual reality simulation, to escape the real world. A teenage orphan finds clues to a contest that promises ownership of the OASIS to the winner, and he and his allies try to complete it before an evil corporation can do so.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/74/Ready_Player_One_%28film%29.png",
                            Price = 19.99m,
                            Title = "Ready Player One"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Description = "Dune (titled onscreen as Dune: Part One) is a 2021 American epic science fiction film directed by Denis Villeneuve, who co-wrote the screenplay with Jon Spaihts and Eric Roth. It is the first of a two-part adaptation of the 1965 novel of the same name by Frank Herbert. Set in the distant future, the film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis. The ensemble cast includes Timothée Chalamet, Rebecca Ferguson, Oscar Isaac, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Zendaya, Chang Chen, Sharon Duncan-Brewster, Charlotte Rampling, Jason Momoa, and Javier Bardem.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8e/Dune_%282021_film%29.jpg/220px-Dune_%282021_film%29.jpg",
                            Price = 29.99m,
                            Title = "Dune"
                        });
                });

            modelBuilder.Entity("BlazorEcomm.Shared.Product", b =>
                {
                    b.HasOne("BlazorEcomm.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}