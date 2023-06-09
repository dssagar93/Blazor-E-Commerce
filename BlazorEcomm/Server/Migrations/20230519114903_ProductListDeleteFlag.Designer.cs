﻿// <auto-generated />
using System;
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
    [Migration("20230519114903_ProductListDeleteFlag")]
    partial class ProductListDeleteFlag
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            Name = "Books",
                            Url = "books",
                            Visibility = true
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            Name = "Movies",
                            Url = "movies",
                            Visibility = true
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            Name = "Video Games",
                            Url = "video-games",
                            Visibility = true
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

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Batman Begins is a 2005 superhero film directed by Christopher Nolan and written by Nolan and David S. Goyer. The film is based on the DC Comics character Batman, it stars Christian Bale as Bruce Wayne / Batman, with Michael Caine, Liam Neeson, Katie Holmes, Gary Oldman, Cillian Murphy, Tom Wilkinson, Rutger Hauer, Ken Watanabe, and Morgan Freeman in supporting roles. The film reboots the Batman film series, telling the origin story of Bruce Wayne from the death of his parents to his journey to become Batman and his fight to stop Ra's al Ghul and the Scarecrow from plunging Gotham City into chaos.",
                            Featured = true,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/a/af/Batman_Begins_Poster.jpg/220px-Batman_Begins_Poster.jpg",
                            Title = "Batman Begins",
                            Visibility = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Ready Player One is a 2018 American science fiction film based on Ernest Cline's novel of the same name. Directed by Steven Spielberg from a screenplay by Zak Penn and Cline, it stars Tye Sheridan, Olivia Cooke, Ben Mendelsohn, Lena Waithe, T.J. Miller, Simon Pegg, and Mark Rylance. The film is set in 2045, where much of humanity uses the OASIS, a virtual reality simulation, to escape the real world. A teenage orphan finds clues to a contest that promises ownership of the OASIS to the winner, and he and his allies try to complete it before an evil corporation can do so.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/74/Ready_Player_One_%28film%29.png",
                            Title = "Ready Player One",
                            Visibility = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            Deleted = false,
                            Description = "Dune (titled onscreen as Dune: Part One) is a 2021 American epic science fiction film directed by Denis Villeneuve, who co-wrote the screenplay with Jon Spaihts and Eric Roth. It is the first of a two-part adaptation of the 1965 novel of the same name by Frank Herbert. Set in the distant future, the film follows Paul Atreides as his family, the noble House Atreides, is thrust into a war for the deadly and inhospitable desert planet Arrakis. The ensemble cast includes Timothée Chalamet, Rebecca Ferguson, Oscar Isaac, Josh Brolin, Stellan Skarsgård, Dave Bautista, Stephen McKinley Henderson, Zendaya, Chang Chen, Sharon Duncan-Brewster, Charlotte Rampling, Jason Momoa, and Javier Bardem.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8e/Dune_%282021_film%29.jpg/220px-Dune_%282021_film%29.jpg",
                            Title = "Dune",
                            Visibility = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                            Title = "The Matrix",
                            Visibility = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                            Featured = true,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                            Title = "Back to the Future",
                            Visibility = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            Deleted = false,
                            Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",
                            Title = "Toy Story",
                            Visibility = true
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",
                            Title = "Half-Life 2",
                            Visibility = true
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                            Title = "Diablo II",
                            Visibility = true
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                            Title = "Day of the Tentacle",
                            Visibility = true
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                            Featured = false,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                            Title = "Xbox",
                            Visibility = true
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            Deleted = false,
                            Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                            Featured = true,
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                            Title = "Super Nintendo Entertainment System",
                            Visibility = true
                        });
                });

            modelBuilder.Entity("BlazorEcomm.Shared.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paperback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "E-Book"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audiobook"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Stream"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Blu-ray"
                        },
                        new
                        {
                            Id = 7,
                            Name = "VHS"
                        },
                        new
                        {
                            Id = 8,
                            Name = "PC"
                        },
                        new
                        {
                            Id = 9,
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Xbox"
                        });
                });

            modelBuilder.Entity("BlazorEcomm.Shared.ProductVariant", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Visibility")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "ProductTypeId");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("ProductVariants");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 19.99m,
                            Price = 9.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 3,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 7.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 1,
                            ProductTypeId = 4,
                            Deleted = false,
                            OriginalPrice = 29.99m,
                            Price = 19.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 2,
                            ProductTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 14.99m,
                            Price = 7.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 3,
                            ProductTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 6.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 3.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 6,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 9.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 4,
                            ProductTypeId = 7,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 19.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 5,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 3.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 6,
                            ProductTypeId = 5,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 2.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 8,
                            Deleted = false,
                            OriginalPrice = 29.99m,
                            Price = 19.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 9,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 69.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 7,
                            ProductTypeId = 10,
                            Deleted = false,
                            OriginalPrice = 59.99m,
                            Price = 49.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 8,
                            ProductTypeId = 8,
                            Deleted = false,
                            OriginalPrice = 24.99m,
                            Price = 9.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 9,
                            ProductTypeId = 8,
                            Deleted = false,
                            OriginalPrice = 0m,
                            Price = 14.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 10,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 299m,
                            Price = 159.99m,
                            Visibility = true
                        },
                        new
                        {
                            ProductId = 11,
                            ProductTypeId = 1,
                            Deleted = false,
                            OriginalPrice = 399m,
                            Price = 79.99m,
                            Visibility = true
                        });
                });

            modelBuilder.Entity("BlazorEcomm.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
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

            modelBuilder.Entity("BlazorEcomm.Shared.ProductVariant", b =>
                {
                    b.HasOne("BlazorEcomm.Shared.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorEcomm.Shared.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("BlazorEcomm.Shared.Product", b =>
                {
                    b.Navigation("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
