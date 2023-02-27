using LibraryBooksWebApi_1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using static Program;

namespace LibraryBooksWebApi.Models
{

    public class ApplicationContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryBooks;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LibraryBooks;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<Rating>().HasCheckConstraint("Score", "Score >=0 AND Score <=5");

            for (int i = 1; i < 50; i++)
            {
                string rndAuthor = RandomData.RandomString(RandomData.topAuthors);
                string rndGenre = RandomData.RandomGenre().ToString();
                string str = RandomData.RndStrInChar(10);
                int score = RandomData.RandomScore();

                modelBuilder.Entity<Book>().HasData(
                new Book[]
                {
                    new Book
                    {
                        Id=i,
                        Title = $"Title{i}",
                        //Cover = "https://lh3.googleusercontent.com/ogw/AAEL6sjPAs3D3hmt8w9N6gkkpFLEvN4LNPUI1_cG7cmadg=s32-c-mo",
                        Cover = $"https://googleusercontent.com/cover{i}.jpg",
                        Content = str,
                        Author = rndAuthor,
                        Genre = rndGenre,
                    }
                }
                );

                modelBuilder.Entity<Rating>().HasData(
                new Rating[]
                {
                     new Rating {Id=i, BookId = i ,Score = score},
                });

                modelBuilder.Entity<Review>().HasData(
                new Review[]
                {
                    new Review
                    {
                        Id=i,
                        BookId = i,
                        message = $"Title{i}\n{rndAuthor}\n{rndGenre}",
                        reviewer = $"Title{i}\n{rndAuthor}\n{rndGenre}\n\t{str}"
                    },
                });

            }
        }
    }
}

