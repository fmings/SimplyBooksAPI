namespace SimplyBooksAPI.Models
{
    public class Book
    {
        public string Id { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool Sale { get; set; }
        public string UserId { get; set; }
        public Author Author { get; set; }
    }
}
