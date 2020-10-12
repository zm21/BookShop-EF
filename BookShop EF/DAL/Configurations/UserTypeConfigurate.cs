    namespace DAL
{
    using System.Data.Entity.ModelConfiguration;

    class UserTypeConfigurate : EntityTypeConfiguration<UserType>
    {
        public UserTypeConfigurate()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}