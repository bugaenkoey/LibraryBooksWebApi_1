using LibraryBooksWebApi.Models;
using LibraryBooksWebApi_1.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryBooksWebApi_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/<ValuesController1>
        //1. Get all books.Order by provided value(title or author)
        //GET https://{{baseUrl}}/api/books?order=author

        [HttpGet]
        public IEnumerable<Book> GetOrder(string order)
        {
            return new QveriesApp().GetAllBooksOrder(order);
        }

        //2. Get top 10 books with high rating and number of reviews greater than 10. 
        //You can filter books by specifying genre.Order by rating
        //GET https://{{baseUrl}}/api/recommended?genre=horror


        [HttpGet("recommended")]
        public IEnumerable<Book> GetTop10(string genre)
        {
            return new QveriesApp().GetTop10(genre);
        }

        //3. Get book details with the list of reviews
        //GET https://{{baseUrl}}/api/books/{id}

        [HttpGet("id")]
        public IEnumerable<Book> GetDetails(int id)
        {
            return new QveriesApp().GetDetails(id);
        }

        //4. Delete a book using a secret key.Save the secret key in the config of your application.Compare this key with a query param
        //DELETE https://{{baseUrl}}/api/books/{id}?secret=qwerty

        [HttpDelete("id")]
        public void DeleteSecret(int id, string secret)
        {
            new QveriesApp().DeleteSecret(id, secret);
        }

        //5. Save a new book.
        //POST https://{{baseUrl}}/api/books/save
        [HttpPost("save")]
        public void Save([FromBody] Book book)
        {
            new QveriesApp().SaveBook(book);

        }

        //6. Save a review for the book.
        //PUT https://{{baseUrl}}/api/books/{id}/review
        [HttpPut("{id}/review")]

        //[AcceptVerbs("PutReview")]
        public void PutReview(int id, [FromBody] Review review)
        {
            new QveriesApp().ReviewAdd(id, review);

        }

        //7. Rate a book
        //PUT https://{{baseUrl}}/api/books/{id}/rate

        [HttpPut("{id}/rate")]
        //[AcceptVerbs("PutRating")]
        public void PutRating(int id, [FromBody] Rating rate)
        {
            new QveriesApp().RatingAdd(id, rate);
        }





    }
}
