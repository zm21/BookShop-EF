namespace BLL
{
    public class BookProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PublishYear { get; set; }
        public int PagesCount { get; set; }
        public string Genre { get; set; }
        public decimal SellingPrice { get; set; }
        public int? Discount { get; set; }
        public int Count { get; set; }
    }
}
