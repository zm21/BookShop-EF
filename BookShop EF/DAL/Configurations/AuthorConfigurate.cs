namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class AuthorConfigurate : EntityTypeConfiguration<Author>
    {
        public AuthorConfigurate()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            this.Property(c => c.LastName).IsRequired().HasMaxLength(50);
            this.Property(c => c.MiddleName).IsRequired().HasMaxLength(50);
            this.HasMany(c => c.Books).WithRequired(r => r.Author).HasForeignKey(r => r.AuthorId);
        }
    }
}