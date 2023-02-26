using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace LibraryBooksWebApi.Models
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryBooks;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LibraryBooks;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            for (int i = 1; i < 50; i++)
            {
                Random rnd = new Random();
                int g = rnd.Next(1, 10);

                Random rnd2 = new Random();
                int s = rnd2.Next(1, 5);

                Random random = new Random();


                string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                string str = new string(Enumerable.Repeat(chars, 15)
                     .Select(s => s[random.Next(s.Length)]).ToArray());


                modelBuilder.Entity<Book>().HasData(
                            new Book[]
                            {
                        new Book
                        {
                            Id=i,
                            Title = $"Title{i}",
                            Cover = "https://lh3.googleusercontent.com/ogw/AAEL6sjPAs3D3hmt8w9N6gkkpFLEvN4LNPUI1_cG7cmadg=s32-c-mo",
                            Content = str,
                            Author = $"Author{g}",
                            Genre = $"Genre{g}",
                            //Ratings=   new List<Rating>()
                            //{ 
                                //new Rating {BookId = i ,Score = s},
                                //new Rating {BookId = i ,Score = s}
                            //},
                            //Reviews = new List<Review>()
                            //{
                                //new Review {BookId = i ,message = str,reviewer = str},
                                //new Review {BookId = i ,message = str,reviewer = str},
                            //}
                //        new Book { Id=7, Title = "Title7",Cover = "https://lh3.googleusercontent.com/ogw/AAEL6sjPAs3D3hmt8w9N6gkkpFLEvN4LNPUI1_cG7cmadg=s32-c-mo",Content = "Content7",Author = "Author7",Genre = "Genre7",Ratings={},Reviews = {}},
                //        new Book { Id=8, Title = "Title8",Cover = "https://lh3.googleusercontent.com/ogw/AAEL6sjPAs3D3hmt8w9N6gkkpFLEvN4LNPUI1_cG7cmadg=s32-c-mo",Content = "Content8",Author = "Author8",Genre = "Genre8",Ratings={},Reviews = {}},
                //        new Book { Id=9, Title = "Title9",Cover = "https://lh3.googleusercontent.com/ogw/AAEL6sjPAs3D3hmt8w9N6gkkpFLEvN4LNPUI1_cG7cmadg=s32-c-mo",Content = "Content9",Author = "Author9",Genre = "Genre9",Ratings={},Reviews = {}},
                
                        }

                            }
                            );

                modelBuilder.Entity<Rating>().HasData(
                   new Rating[]
                   {

                        //new Rating {BookId = i ,Score = s},
                        new Rating {Id=i, BookId = i ,Score = s}

                   }
                   );

                modelBuilder.Entity<Review>().HasData(
                    new Review[]
                    {
                        //new Review {BookId = i ,message = str,reviewer = str},
                        new Review {Id=i, BookId = i ,message = str,reviewer = str},
                    }
                    );

            }
        }
    }
}

