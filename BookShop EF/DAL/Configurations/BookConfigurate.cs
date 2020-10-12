namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class BookConfigurate : EntityTypeConfiguration<Book>
    {
        public BookConfigurate()
        {
            this.HasKey(r => r.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(50);
            this.HasOptional(b => b.SequelTo).WithMany().HasForeignKey(b=>b.SequelToId);
        }
    }
}