namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class ProductConfigurate : EntityTypeConfiguration<Product>
    {
        public ProductConfigurate()
        {
            this.HasKey(r => r.BookId);
            this.HasRequired(r => r.Book).WithRequiredDependent(b => b.Product);
        }
    }
}