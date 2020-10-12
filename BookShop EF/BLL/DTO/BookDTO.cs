namespace BLL
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int PublishYear { get; set; }
        public int PagesCount { get; set; }
        public int GenreId { get; set; }
        public int? SequelToId { get; set; }
    }
}
