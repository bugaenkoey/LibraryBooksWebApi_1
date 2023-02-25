using LibraryBooksWebApi.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace LibraryBooksWebApi_1.Queries
{


    public class QveriesApp
    {
        public QveriesApp() { }

        //1. Get all books.Order by provided value(title or author)
        //GET https://{{baseUrl}}/api/books?order=author
        public IEnumerable<Book> GetAllBooksOrder(string order)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var books = (from b in db.Books
                             where b.Title == order || b.Author == order
                             select b).ToList();

                foreach (var book in books)
                    Console.WriteLine($"{book.Id}  {book.Title} {book.Author} {book.Ratings} {book.Reviews.Count}");


                return books;
            }
        }



        //2. Get top 10 books with high rating and number of reviews greater than 10. 
        //You can filter books by specifying genre.Order by rating
        //GET https://{{baseUrl}}/api/recommended?genre=horror

        public IEnumerable<Book> GetTop10(string recommended)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var topBooks = (from b in db.Books
                                where b.Genre == recommended
                                select b);
               //TO DO              

                return topBooks;
            }
        }


        //3. Get book details with the list of reviews
        //GET https://{{baseUrl}}/api/books/{id}

        public IEnumerable<Book> GetDetails(int id)
        {
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    var topBooks = (from b in db.Books
            //                    where b.Id == id
            //                    select b);
            //    //TO DO              

            //    return topBooks;
            //}

            throw new NotImplementedException();
        }


        //4. Delete a book using a secret key.Save the secret key in the config of your application.Compare this key with a query param
        //DELETE https://{{baseUrl}}/api/books/{id}?secret=qwerty

        internal void DeleteSecret(int id, string secret)
        {
            throw new NotImplementedException();
        }

        //5. Save a new book.
        //POST https://{{baseUrl}}/api/books/save

        internal void SaveBook(Book book)
        {
            throw new NotImplementedException();
        }


        //6. Save a review for the book.
        //PUT https://{{baseUrl}}/api/books/{id}/review

        internal void ReviewAdd(int id, Review review)
        {
            throw new NotImplementedException();
        }


        //7. Rate a book
        //PUT https://{{baseUrl}}/api/books/{id}/rate

        internal void RatingAdd(int id, Rating rate)
        {
            throw new NotImplementedException();
        }

    }
}
