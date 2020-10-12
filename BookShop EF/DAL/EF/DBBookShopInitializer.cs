using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    class DBRentPremisesInitializer : DropCreateDatabaseIfModelChanges<BookShopModel>
    {
        protected override void Seed(BookShopModel context)
        {
            base.Seed(context);

            List<UserType> userTypes = new List<UserType>()
            {
                new UserType()
                {
                    Name = "User"
                },
                new UserType()
                {
                    Name = "Admin"
                }
            };
            context.UserTypes.AddRange(userTypes);
            context.SaveChanges();

            List<Genre> genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "Horror"
                },
                new Genre()
                {
                    Name = "Roman"
                },
                new Genre()
                {
                    Name = "Happy"
                }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();

            List<Author> authors = new List<Author>()
            {
                new Author()
                {
                    FirstName = "Piotr",
                    LastName = "Hugonneau",
                    MiddleName = "Mingardi"
                },
                new Author()
                {
                    FirstName = "Christal",
                    LastName = "Robker",
                    MiddleName = "Scally"
                },
                new Author()
                {
                    FirstName = "Iosep",
                    LastName = "Baudinot",
                    MiddleName = "Worms"
                }
            };

            context.Authors.AddRange(authors);
            context.SaveChanges();

            List<Publisher> publishers = new List<Publisher>()
            {
                new Publisher()
                {
                    Name = "Latlux"
                },
                new Publisher()
                {
                    Name = "Opela"
                },
                new Publisher()
                {
                    Name = "Y-find"
                },
            };

            context.Publishers.AddRange(publishers);
            context.SaveChanges();

            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Name = "Fintone",
                    GenreId = 1,
                    AuthorId = 1,
                    PublisherId=1,
                    PublishYear=1998,
                    PagesCount = 155,
                },
                new Book()
                {
                    Name = "Matsoft",
                    AuthorId = 2,
                    GenreId = 2,
                    PublisherId=2,
                    PublishYear=1999,
                    PagesCount = 155
                },
                new Book()
                {
                    Name = "Bamity",
                    AuthorId = 3,
                    GenreId = 3,
                    PublisherId=3,
                    PublishYear=2000,
                    PagesCount = 155
                }
            };

            context.Books.AddRange(books);
            context.SaveChanges();
        }
    }
}
