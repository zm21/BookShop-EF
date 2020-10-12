using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Author> AuthorRepository { get; }
        IGenericRepository<Book> BookRepository { get; }
        IGenericRepository<Genre> GenreRepository { get; }
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<Publisher> PublisherRepository { get; }
        IGenericRepository<Reserv> ReservRepository { get; }
        IGenericRepository<Sale> SaleRepository { get; }
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<UserType> UserTypeRepository { get; }
        void Commit();
    }
}
