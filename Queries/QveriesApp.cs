using LibraryBooksWebApi.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Text.Json.Nodes;
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
            return books;
        }

        //2. Get top 10 books with high rating and number of reviews greater than 10. 
        //You can filter books by specifying genre.Order by rating
        //GET https://{{baseUrl}}/api/recommended?genre=horror

        public IEnumerable<Book> GetTop10(string genre)
        //public string GetTop10(string genre)
        {
            genre = genre.ToLower();

            using (ApplicationContext db = new ApplicationContext())
            {
                var top10Books = (from book in db.Books
                                  where book.Genre == genre
                                  select book).ToList();
                return top10Books;
            }
        }


        //3. Get book details with the list of reviews
        //GET https://{{baseUrl}}/api/books/{id}

        public Object GetDetails(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var topBooks = (db.Books.Find(id));

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
                //видаляємо обєкт
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

        internal Review ReviewAdd(int bookId, Review review)
        {

            using ApplicationContext db = new ApplicationContext();

            if (db.Reviews.Find(review.Id) != null)
            {
                review.BookId = bookId;
                db.Reviews.Update(review);
                return review;
            }
            else
            {
                Review new_review = new Review();
                new_review.message = review.message;
                new_review.BookId = bookId;
                new_review.reviewer = review.reviewer;

                db.Reviews.Add(new_review);
                db.SaveChanges();
                return new_review;
            }
        }

        //7. Rate a book
        //PUT https://{{baseUrl}}/api/books/{id}/rate

        internal Rating RatingAdd(int bookId, Rating rate)
        {
            using ApplicationContext db = new ApplicationContext();

            if (db.Ratings.Find(rate.Id) != null)
            {
                rate.BookId = bookId;
                db.Ratings.Update(rate);
                return rate;
            }
            else
            {
                Rating new_rate = new Rating();
                new_rate.BookId = bookId;
                new_rate.Score = rate.Score;
                //new_rate.Book = rate.Book;

                db.Ratings.Add(new_rate);
                db.SaveChanges();
                return new_rate;
            }
        }

    }
}
