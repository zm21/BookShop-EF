namespace DAL
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public int PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int PublishYear { get; set; }
        public int PagesCount { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int? SequelToId { get; set; }
        public virtual Book SequelTo { get; set; }
        public virtual Product Product { get; set; }
    }
}