namespace LibraryBooksWebApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string message { get; set; }
        public int BookId { get; set; }
        public string reviewer { get; set; }
        public Book Book { get; set; }

    }
}