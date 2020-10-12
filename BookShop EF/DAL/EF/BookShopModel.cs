namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookShopModel : DbContext
    {
        // Your context has been configured to use a 'BookShopModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.BookShopModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookShopModel' 
        // connection string in the application configuration file.
        public BookShopModel()
            : base("name=BookShopModel")
        {
            Database.SetInitializer(new DBRentPremisesInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AuthorConfigurate());
            modelBuilder.Configurations.Add(new BookConfigurate());
            modelBuilder.Configurations.Add(new GenreConfigurate());
            modelBuilder.Configurations.Add(new ProductConfigurate());
            modelBuilder.Configurations.Add(new PublisherConfigurate());
            modelBuilder.Configurations.Add(new ReservConfigurate());
            modelBuilder.Configurations.Add(new SaleConfigurate());
            modelBuilder.Configurations.Add(new UserConfigurate());
            modelBuilder.Configurations.Add(new UserTypeConfigurate());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Reserv> Reservs { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}