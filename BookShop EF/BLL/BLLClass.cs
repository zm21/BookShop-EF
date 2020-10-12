using AutoMapper;
using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLClass : IBLLClass
    {
        private IMapper _mapper = null;
        private UnitOfWork _unitOfWork = null;
        public BLLClass()
        {
            _unitOfWork = new UnitOfWork(new BookShopModel());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ForMember(c => c.Passwd, opt => opt.Ignore());
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Book, BookDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<Publisher, PublisherDTO>();
                cfg.CreateMap<Reserv, ReservDTO>();
                cfg.CreateMap<Sale, SaleDTO>();
                cfg.CreateMap<UserType, UserTypeDTO>();

                cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.PasswdHash,
                                               opt => opt.MapFrom(src => Utils.ComputeSha256Hash(src.Passwd)));
                cfg.CreateMap<AuthorDTO, Author>();
                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<GenreDTO, Genre>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<PublisherDTO, Publisher>();
                cfg.CreateMap<ReservDTO, Reserv>();
                cfg.CreateMap<SaleDTO, Sale>();
                cfg.CreateMap<UserTypeDTO, UserType>();
            });

            _mapper = new Mapper(config);
        }

        public void AddUser(UserDTO user)
        {
            _unitOfWork.UserRepository.Insert(_mapper.Map<User>(user));
            _unitOfWork.Commit();
        }

        public IEnumerable<AuthorDTO> GetAuthors()
        {
            return _mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(_unitOfWork.AuthorRepository.Get());
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_unitOfWork.BookRepository.Get());
        }

        public IEnumerable<PublisherDTO> GetPublishers()
        {
            return _mapper.Map<IEnumerable<Publisher>, IEnumerable<PublisherDTO>>(_unitOfWork.PublisherRepository.Get());
        }

        public UserDTO GetUserByLoginAndPassword(string login, string passwd)
        {
            return _mapper.Map<UserDTO>(_unitOfWork.UserRepository.Get(u=>u.Login==login && u.PasswdHash == Utils.ComputeSha256Hash(passwd)));
        }

        public bool IsExistsUserByLoginAndPassword(string login, string passwd)
        {
            return _unitOfWork.UserRepository.Get(u => u.Login == login && u.PasswdHash == Utils.ComputeSha256Hash(passwd)).Count() > 0;
        }

        public bool IsExistUserWithThisLogin(string login)
        {
            return _unitOfWork.UserRepository.Get(u => u.Login == login)?.ToList()?.Count() > 0;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_unitOfWork.ProductRepository.Get());
        }

        public void AddAuthor(AuthorDTO authorDTO)
        {
            _unitOfWork.AuthorRepository.Insert(_mapper.Map<Author>(authorDTO));
            _unitOfWork.Commit();
        }

        public bool IsExistAuthor(AuthorDTO authorDTO)
        {
            return _unitOfWork.AuthorRepository.Get(a => a.FirstName == authorDTO.FirstName && a.LastName == authorDTO.LastName && a.MiddleName == authorDTO.MiddleName).Count() != 0;
        }

        public void EditAuthor(AuthorDTO authorDTO)
        {
            var author = _unitOfWork.AuthorRepository.GetByID(authorDTO.Id);
            _unitOfWork.AuthorRepository.Update(author);
            author.FirstName = authorDTO.FirstName;
            author.LastName = authorDTO.LastName;
            author.MiddleName = authorDTO.MiddleName;
            _unitOfWork.Commit();
        }

        public IEnumerable<GenreDTO> GetGenres()
        {
            return _mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(_unitOfWork.GenreRepository.Get());
        }

        public void AddBook(BookDTO bookDTO)
        {
            _unitOfWork.BookRepository.Insert(_mapper.Map<Book>(bookDTO));
            _unitOfWork.Commit();
        }

        public void EditBook(BookDTO bookDTO)
        {
            var book = _unitOfWork.BookRepository.GetByID(bookDTO.Id);
            _unitOfWork.BookRepository.Update(book);
            book.Name = bookDTO.Name;
            book.PagesCount = bookDTO.PagesCount;
            book.PublishYear = bookDTO.PublishYear;
            book.AuthorId = bookDTO.AuthorId;
            book.GenreId = bookDTO.GenreId;
            book.PublisherId = bookDTO.PublisherId;
            if(bookDTO.SequelToId!=0)
                book.SequelToId = bookDTO.SequelToId;
            _unitOfWork.Commit();
        }

        public void AddPublisher(PublisherDTO publisherDTO)
        {
            _unitOfWork.PublisherRepository.Insert(_mapper.Map<Publisher>(publisherDTO));
            _unitOfWork.Commit();
        }

        public bool IsExistPublisher(PublisherDTO publisherDTO)
        {
            return _unitOfWork.PublisherRepository.Get(p=>p.Name == publisherDTO.Name).Count() != 0;
        }

        public void EditPublisher(PublisherDTO publisherDTO)
        {
            var publisher = _unitOfWork.PublisherRepository.GetByID(publisherDTO.Id);
            _unitOfWork.PublisherRepository.Update(publisher);
            publisher.Name = publisherDTO.Name;
            _unitOfWork.Commit();
        }

        public void AddProduct(ProductDTO productDTO)
        {
            _unitOfWork.ProductRepository.Insert(_mapper.Map<Product>(productDTO));
            _unitOfWork.Commit();
        }

        public void EditProduct(ProductDTO productDTO)
        {
            var product = _unitOfWork.ProductRepository.GetByID(productDTO.BookId);
            _unitOfWork.ProductRepository.Update(product);
            product.Cost = productDTO.Cost;
            product.SellingPrice = productDTO.SellingPrice;
            product.Count = productDTO.Count;
            product.Discount = productDTO.Discount;
            _unitOfWork.Commit();
        }

        public IEnumerable<BookDTO> GetBooksForProducts()
        {
            var prod = _unitOfWork.ProductRepository.Get().Select(p => p.BookId);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookDTO>>(_unitOfWork.BookRepository.Get(b => !prod.Contains(b.Id)));
        }

        public UserTypeDTO GetUserType(UserDTO userDTO)
        {
            return _mapper.Map<UserTypeDTO>(_unitOfWork.UserTypeRepository.GetByID(userDTO.UserTypeId));
        }

        public IEnumerable<ReservDTO> GetReservs(UserDTO userDTO)
        {
            return _mapper.Map<IEnumerable<Reserv>, IEnumerable<ReservDTO>>(_unitOfWork.ReservRepository.Get(r => r.UserId == userDTO.Id));
        }

        public IEnumerable<SaleDTO> GetSales(UserDTO userDTO)
        {
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(_unitOfWork.SaleRepository.Get(r => r.UserId == userDTO.Id));
        }
        public IEnumerable<SaleDTO> GetAllSales()
        {
            return _mapper.Map<IEnumerable<Sale>, IEnumerable<SaleDTO>>(_unitOfWork.SaleRepository.Get());
        }

        public IEnumerable<BookProductDTO> GetBookProduct()
        {
            var bids = _unitOfWork.ProductRepository.Get().Select(b => b.BookId);
            var books = _unitOfWork.BookRepository.Get(b=> bids.Contains(b.Id), includeProperties: nameof(Book.Product) + ',' + nameof(Book.Author) + ',' + nameof(Book.Publisher)
                + ',' + nameof(Book.Genre));
            List<BookProductDTO> bookProductDTOs = new List<BookProductDTO>();
            foreach (var item in books)
            {
                bookProductDTOs.Add(new BookProductDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Author = $"{item.Author.FirstName} {item.Author.LastName} {item.Author.MiddleName}",
                    Publisher = item.Publisher.Name,
                    PublishYear = item.PublishYear,
                    PagesCount = item.PagesCount,
                    Genre = item.Genre.Name,
                    Count = item.Product.Count,
                    Discount = item.Product.Discount,
                    SellingPrice = item.Product.SellingPrice
                });
            }
            return bookProductDTOs;
        }

        public void BuyBook(BookProductDTO bookProductDTO, UserDTO userDTO)
        {
            var prod = _unitOfWork.ProductRepository.GetByID(bookProductDTO.Id);
            if(prod.Count>0)
            {
                prod.Count--;
                var disc = prod.Discount ?? 0;
                SaleDTO sale = new SaleDTO()
                {
                    ProductId = prod.BookId,
                    UserId = userDTO.Id,
                    TotalPrice = prod.SellingPrice - ((prod.SellingPrice * disc) / 100)
                };
                _unitOfWork.SaleRepository.Insert(_mapper.Map<Sale>(sale));
                _unitOfWork.Commit();
            }
        }

        public void ReservBook(BookProductDTO bookProductDTO, UserDTO userDTO)
        {
            var prod = _unitOfWork.ProductRepository.GetByID(bookProductDTO.Id);
            if (prod.Count > 0)
            {
                prod.Count--;
                var disc = prod.Discount ?? 0;

                ReservDTO reservDTO = new ReservDTO()
                {
                    ProductId = prod.BookId,
                    UserId =userDTO.Id,
                    IsActive = true,
                };
                _unitOfWork.ReservRepository.Insert(_mapper.Map<Reserv>(reservDTO));
                _unitOfWork.Commit();
            }
        }

        public void CancelReserv(ReservDTO reservDTO)
        {
            var res = _unitOfWork.ReservRepository.GetByID(reservDTO.Id);
            _unitOfWork.ReservRepository.Update(res);
            var prod = _unitOfWork.ProductRepository.GetByID(res.ProductId);
            _unitOfWork.ProductRepository.Update(prod);
            prod.Count++;
            res.IsActive = false;
            _unitOfWork.Commit();
        }

        public bool IsUserReservBook(BookProductDTO bookProductDTO, UserDTO userDTO)
        {
            var prod = _unitOfWork.ProductRepository.GetByID(bookProductDTO.Id);
            return _unitOfWork.ReservRepository.Get(r => r.ProductId == prod.BookId && r.UserId == userDTO.Id && r.IsActive).Count()!=0;
        }

        public void BuyFromReserv(ReservDTO reservDTO)
        {
            var res = _unitOfWork.ReservRepository.GetByID(reservDTO.Id);
            _unitOfWork.ReservRepository.Update(res);
            var prod = _unitOfWork.ProductRepository.GetByID(res.ProductId);
            var disc = prod.Discount ?? 0;
            SaleDTO sale = new SaleDTO()
            {
                ProductId = prod.BookId,
                UserId = res.UserId,
                TotalPrice = prod.SellingPrice - ((prod.SellingPrice * disc) / 100)
            };
            res.IsActive = false;
            _unitOfWork.SaleRepository.Insert(_mapper.Map<Sale>(sale));
            _unitOfWork.Commit();
        }

        public BookDTO MostSalledBook()
        {
            var sales = _unitOfWork.SaleRepository.Get();
            int book_id = sales.GroupBy(b => b.ProductId).OrderByDescending(g => g.Count()).First().Key;
            return _mapper.Map<BookDTO>(_unitOfWork.BookRepository.GetByID(book_id));
        }

        public AuthorDTO MostWriterAuthor()
        {
            return  _mapper.Map<AuthorDTO>(_unitOfWork.AuthorRepository.Get().OrderByDescending(a => a.Books.Count()).First());
        }

        public GenreDTO MostPopularGenre()
        {
            return _mapper.Map<GenreDTO>(_unitOfWork.GenreRepository.Get().OrderByDescending(g => g.Books.Count()).First());
        }
    }
}
