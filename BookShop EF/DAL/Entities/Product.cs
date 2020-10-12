namespace DAL
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public Product()
        {
            this.Sales = new HashSet<Sale>();
            this.Reservs = new HashSet<Reserv>();
        }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public decimal Cost { get; set; }
        public decimal SellingPrice { get; set; }
        public int? Discount { get; set; }
        public int Count { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<Reserv> Reservs { get; set; }
    }
}