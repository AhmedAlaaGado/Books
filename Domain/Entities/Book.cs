namespace Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public string Genre { get; set; }
        public int PublishedYear { get; set; }

        public Author Author { get; set; }
        public Publisher Publisher { get; set; }
    }
}
