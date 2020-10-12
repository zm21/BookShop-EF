namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class ReservConfigurate : EntityTypeConfiguration<Reserv>
    {
        public ReservConfigurate()
        {
            this.HasKey(r => r.Id);
            this.HasRequired(r => r.Product).WithMany(p => p.Reservs).HasForeignKey(r => r.ProductId);
        }
    }
}