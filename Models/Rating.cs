using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryBooksWebApi.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [Range(1, 5)]
        public int Score { get; set; }
        public Book Book { get; set; }
    }
}
