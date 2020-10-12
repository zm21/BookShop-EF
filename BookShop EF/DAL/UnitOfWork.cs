using System;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookShopModel context;
        public UnitOfWork(BookShopModel context)
        {
            this.context = context;
        }
        //private IRepository<Author> _authorRepository;
        //private IRepository<Book> _bookRepository;
        //private IRepository<Genre> _genreRepository;
        //private IRepository<Product> _productRepository;
        //private IRepository<Publisher> _publisherRepository;
        //private IRepository<Reserv> _reservRepository;
        //private IRepository<Sale> _saleRepository;
        //private IRepository<User> _userRepository;
        //private IRepository<UserType> _userTypeRepository;

        //public IRepository<Author> AuthorRepository
        //{
        //    get
        //    {
        //        return _authorRepository ?? (_authorRepository = new AuthorRepository(context));
        //    }
        //}
        //public IRepository<Book> BookRepository
        //{
        //    get
        //    {
        //        return _bookRepository ?? (_bookRepository = new BookRepository(context));
        //    }
        //}

        //public IRepository<Genre> GenreRepository
        //{
        //    get
        //    {
        //        return _genreRepository ?? (_genreRepository = new GenreRepository(context));
        //    }
        //}
        //public IRepository<Product> ProductRepository
        //{
        //    get
        //    {
        //        return _productRepository ?? (_productRepository = new ProductRepository(context));
        //    }
        //}
        //public IRepository<Publisher> PublisherRepository
        //{
        //    get
        //    {
        //        return _publisherRepository ?? (_publisherRepository = new PublisherRepository(context));
        //    }
        //}
        //public IRepository<Reserv> ReservRepository
        //{
        //    get
        //    {
        //        return _reservRepository ?? (_reservRepository = new ReservRepository(context));
        //    }
        //}
        //public IRepository<Sale> SaleRepository
        //{
        //    get
        //    {
        //        return _saleRepository ?? (_saleRepository = new SaleRepository(context));
        //    }
        //}
        //public IRepository<User> UserRepository
        //{
        //    get
        //    {
        //        return _userRepository ?? (_userRepository = new UserRepository(context));
        //    }
        //}
        //public IRepository<UserType> UserTypeRepository
        //{
        //    get
        //    {
        //        return _userTypeRepository ?? (_userTypeRepository = new UserTypeRepository(context));
        //    }
        //}

        //GenericRepository
        private IGenericRepository<Author> _authorRepository;
        private IGenericRepository<Book> _bookRepository;
        private IGenericRepository<Genre> _genreRepository;
        private IGenericRepository<Product> _productRepository;
        private IGenericRepository<Publisher> _publisherRepository;
        private IGenericRepository<Reserv> _reservRepository;
        private IGenericRepository<Sale> _saleRepository;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<UserType> _userTypeRepository;

        public IGenericRepository<Author> AuthorRepository
        {
            get
            {
                return _authorRepository ?? (_authorRepository = new GenericRepository<Author>(context));
            }
        }
        public IGenericRepository<Book> BookRepository
        {
            get
            {
                return _bookRepository ?? (_bookRepository = new GenericRepository<Book>(context));
            }
        }

        public IGenericRepository<Genre> GenreRepository
        {
            get
            {
                return _genreRepository ?? (_genreRepository = new GenericRepository<Genre>(context));
            }
        }
        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                return _productRepository ?? (_productRepository = new GenericRepository<Product>(context));
            }
        }
        public IGenericRepository<Publisher> PublisherRepository
        {
            get
            {
                return _publisherRepository ?? (_publisherRepository = new GenericRepository<Publisher>(context));
            }
        }
        public IGenericRepository<Reserv> ReservRepository
        {
            get
            {
                return _reservRepository ?? (_reservRepository = new GenericRepository<Reserv>(context));
            }
        }
        public IGenericRepository<Sale> SaleRepository
        {
            get
            {
                return _saleRepository ?? (_saleRepository = new GenericRepository<Sale>(context));
            }
        }
        public IGenericRepository<User> UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new GenericRepository<User>(context));
            }
        }
        public IGenericRepository<UserType> UserTypeRepository
        {
            get
            {
                return _userTypeRepository ?? (_userTypeRepository = new GenericRepository<UserType>(context));
            }
        }

        public void Commit()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
