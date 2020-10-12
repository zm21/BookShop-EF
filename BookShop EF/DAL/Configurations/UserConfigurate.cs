namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class UserConfigurate : EntityTypeConfiguration<User>
    {
        public UserConfigurate()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Login).IsRequired().HasMaxLength(50);
            this.Property(c => c.Email).IsRequired().HasMaxLength(50);
            this.Property(c => c.PasswdHash).IsRequired().HasMaxLength(512);
            this.HasRequired(c => c.UserType).WithMany(ut => ut.Users).HasForeignKey(c => c.UserTypeId);
            this.HasMany(c => c.Reservs).WithRequired(r => r.User).HasForeignKey(r => r.UserId);
            this.HasMany(c => c.Sales).WithRequired(s => s.User).HasForeignKey(s => s.UserId);
        }
    }
}