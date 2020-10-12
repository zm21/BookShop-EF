namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class GenreConfigurate : EntityTypeConfiguration<Genre>
    {
        public GenreConfigurate()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(50);
            this.HasMany(c => c.Books).WithRequired(r => r.Genre).HasForeignKey(r => r.GenreId);
        }
    }
}