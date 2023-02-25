using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBooksWebApi.Models
{
    public class Book
    {

        //id Title Cover Content Author Genre 


//#   "id": "number",
//#   "title": "string",
//#   "author": "string",
//#   "cover": "string",
//#   "content": "string",
//#   "rating": "decimal",          	average rating
//#   "reviews": [{
//#           "id": "number",
//#           "message": "string",
//#           "reviewer": "string",
//#   }]

        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Url]
        public string Cover { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public List<Rating> Ratings { get; set; } = new List<Rating>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
