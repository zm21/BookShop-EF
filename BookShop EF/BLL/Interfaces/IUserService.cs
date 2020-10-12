using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IUserService
    {
        void AddUser(UserDTO user);
        IEnumerable<UserTypeDTO> GetAllUserTypes();
        UserDTO GetUserByLoginAndPassword(string login, string passwd);
        bool IsExistsUserByLoginAndPassword(string login, string passwd);
        bool IsExistUserWithThisLogin(string login);
    }
}
