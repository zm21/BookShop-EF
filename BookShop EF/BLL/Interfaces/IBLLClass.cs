using System.Collections.Generic;

namespace BLL
{
    public interface IBLLClass
    {
        void AddUser(UserDTO user);
        bool IsExistsUserByLoginAndPassword(string login, string passwd);
        UserDTO GetUserByLoginAndPassword(string login, string passwd);
        bool IsExistUserWithThisLogin(string login);
        IEnumerable<BookDTO> GetBooks();
        IEnumerable<AuthorDTO> GetAuthors();
        IEnumerable<PublisherDTO> GetPublishers();
        IEnumerable<GenreDTO> GetGenres();
        IEnumerable<ProductDTO> GetProducts();
        void AddAuthor(AuthorDTO authorDTO);
        bool IsExistAuthor(AuthorDTO authorDTO);
        void EditAuthor(AuthorDTO authorDTO);
        void AddBook(BookDTO bookDTO);
        void EditBook(BookDTO bookDTO);
        void AddPublisher(PublisherDTO publisherDTO);
        bool IsExistPublisher(PublisherDTO publisherDTO);
        void EditPublisher(PublisherDTO publisherDTO);
        void AddProduct(ProductDTO productDTO);
        void EditProduct(ProductDTO productDTO);
        IEnumerable<BookDTO> GetBooksForProducts();
        UserTypeDTO GetUserType(UserDTO userDTO);
        IEnumerable<ReservDTO> GetReservs(UserDTO userDTO);
        IEnumerable<SaleDTO> GetSales(UserDTO userDTO);
        IEnumerable<SaleDTO> GetAllSales();
        IEnumerable<BookProductDTO> GetBookProduct();
        void BuyBook(BookProductDTO bookProductDTO, UserDTO userDTO);
        void ReservBook(BookProductDTO bookProductDTO, UserDTO userDTO);
        void CancelReserv(ReservDTO reservDTO);
        bool IsUserReservBook(BookProductDTO bookProductDTO, UserDTO userDTO);
        void BuyFromReserv(ReservDTO reservDTO);
        BookDTO MostSalledBook();
        AuthorDTO MostWriterAuthor();
        GenreDTO MostPopularGenre();
    }
}
