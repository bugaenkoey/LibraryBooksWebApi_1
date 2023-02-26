using LibraryBooksWebApi.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryBooksWebApi_1.Queries
{


    public class QveriesApp
    {
        public QveriesApp() { }

        //1. Get all books.Order by provided value(title or author)
        //GET https://{{baseUrl}}/api/books?order=author
        public IEnumerable<Book> GetAllBooksOrder(string order)
        {
            using ApplicationContext db = new ApplicationContext();

            var books = (from b in db.Books
                         where b.Title == order || b.Author == order
                         select b).ToList();

            foreach (var book in books)
                Console.WriteLine($"{book.Id}  {book.Title} {book.Author} {book.Ratings} {book.Reviews.Count}");


            return books;
        }



        //2. Get top 10 books with high rating and number of reviews greater than 10. 
        //You can filter books by specifying genre.Order by rating
        //GET https://{{baseUrl}}/api/recommended?genre=horror

        public IEnumerable<Book> GetTop10(string recommended)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var top10Books = db.Books
                    .Select(b => new
                    {
                        Book = b,
                        AverageRating = db.Ratings
                            .Where(br => br.BookId == b.Id)
                            .Average(br => br.Score)
                    })
                    .OrderByDescending(x => x.AverageRating)
                    .Take(10)
                    .Select(x => x.Book);

                return top10Books;
            }
        }


        //3. Get book details with the list of reviews
        //GET https://{{baseUrl}}/api/books/{id}

        public Object GetDetails(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var topBooks = ( db.Books.Find(id)
                               
                                //,
                    //(from rat in db.Ratings
                    // where rat.BookId == id
                    // select rat.Score).Average(),
                    //           (from rev in db.Reviews
                    //            where rev.BookId == id
                    //            select rev)
                               );


                //(from b in db.Books
                //             where b.Id == id
                //             select b);


                //var topBooks = db.Books
                //     .OrderByDescending(b => b.Ratings)
                //     .Take(10)
                //     .Select(b => new
                //     {
                //         b.Id,
                //         b.Title,
                //         b.Author,
                //         b.Cover,
                //         b.Content,
                //         b.Ratings,
                //         Reviews = db.Reviews
                //             .Where(r => r.BookId == b.Id)
                //             .Select(r => new
                //             {
                //                 r.Id,
                //                 r.message,
                //                 r.reviewer
                //             }).ToList()
                //     }).ToList();

                return topBooks;
            }

           
        }


        //4. Delete a book using a secret key.Save the secret key in the config of your application.Compare this key with a query param
        //DELETE https://{{baseUrl}}/api/books/{id}?secret=qwerty

        internal void DeleteSecret(int id, string secret)
        {
            string secretConst = "qwerty";
            using ApplicationContext db = new ApplicationContext();

            Book book = db.Books.Find(id);
            if (book != null && secret.Equals(secretConst))
            {
                //удаляем объект
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        //5. Save a new book.
        //POST https://{{baseUrl}}/api/books/save

        internal Book SaveBook(Book book)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Books.Add(book);
            db.SaveChanges();

            return book;
        }


        //6. Save a review for the book.
        //PUT https://{{baseUrl}}/api/books/{id}/review

        internal Review ReviewAdd(int id, Review review)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Reviews.Add(review);
            db.SaveChanges();

            return review;
        }


        //7. Rate a book
        //PUT https://{{baseUrl}}/api/books/{id}/rate

        internal Rating RatingAdd(int id, Rating rate)
        {
            using ApplicationContext db = new ApplicationContext();
            db.Ratings.Add(rate);
            db.SaveChanges();

            return rate;
        }

    }
}
