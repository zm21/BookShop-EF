namespace BLL
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
