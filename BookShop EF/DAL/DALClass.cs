using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    

    //public interface IDALClass
    //{
    //    bool IsExistsUserByLoginAndPassword(string login, string passHash);
    //    User GetUserByLoginAndPassword(string login, string passHash);
    //    bool IsExistUserWithThisLogin(string login);
    //}
    //public class DALClass : IDALClass
    //{
    //    private IUnitOfWork _unitOfWork = null;
    //    public DALClass()
    //    {
    //        _unitOfWork = new UnitOfWork(new BookShopModel());
    //    }
    //    public User GetUserByLoginAndPassword(string login, string passHash)
    //    {
    //        //var client = _ctx_bookshop.Users.FirstOrDefault(u => u.Login == login && u.PasswdHash == passHash);

    //        var client = _unitOfWork.UserRepository.Get(u => u.Login == login && u.PasswdHash == passHash)?.First();

    //        return client;
    //    }

    //    public bool IsExistUserWithThisLogin(string login)
    //    {
    //        var client = _ctx_bookshop.Users.FirstOrDefault(u => u.Login == login);

    //        return client != null;
    //    }

    //    public bool IsExistsUserByLoginAndPassword(string login, string passHash)
    //    {
    //        var client = _ctx_bookshop.Users.FirstOrDefault(u => u.Login == login && u.PasswdHash == passHash);

    //        return client != null;
    //    }
    //}
}
