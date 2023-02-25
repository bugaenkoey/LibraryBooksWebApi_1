using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
            
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=LibraryBooks;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=LibraryBooks;Trusted_Connection=True;");
        }



    }
}
