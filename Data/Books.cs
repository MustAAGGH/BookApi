namespace Data
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get ; set; }
        public int PublishingYear { get; set; }
        public int AuthorId { get; set; }
        public Authors Author { get; set; }
        public int GenreId { get; set; }
        public Genres Genre { get; set; }
    }
}