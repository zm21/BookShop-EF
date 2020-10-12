namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class SaleConfigurate : EntityTypeConfiguration<Sale>
    {
        public SaleConfigurate()
        {
            this.HasKey(c => c.Id);
            this.HasRequired(s => s.Product).WithMany(p => p.Sales).HasForeignKey(s => s.ProductId);
        }
    }
}