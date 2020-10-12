namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class PublisherConfigurate : EntityTypeConfiguration<Publisher>
    {
        public PublisherConfigurate()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(50);
            this.HasMany(c => c.Books).WithRequired(r => r.Publisher).HasForeignKey(r => r.PublisherId);
        }
    }
}