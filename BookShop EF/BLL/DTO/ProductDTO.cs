namespace BLL
{
    public class ProductDTO
    {
        public int BookId { get; set; }
        public decimal Cost { get; set; }
        public decimal SellingPrice { get; set; }
        public int? Discount { get; set; }
        public int Count { get; set; }
    }
}
