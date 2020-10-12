using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork = null;
        private IMapper _mapper = null;
        public UserService()
        {
            _unitOfWork = new UnitOfWork(new BookShopModel());
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ForMember(c => c.Passwd, opt => opt.Ignore());
                cfg.CreateMap<UserType, UserTypeDTO>();
                cfg.CreateMap<UserDTO, User>().ForMember(dest => dest.PasswdHash,
                                               opt => opt.MapFrom(src => Utils.ComputeSha256Hash(src.Passwd)));
                cfg.CreateMap<UserTypeDTO, UserType>();
            });

            _mapper = new Mapper(config);

        }
        public void AddUser(UserDTO user)
        {
            _unitOfWork.UserRepository.Insert(_mapper.Map<User>(user));
            _unitOfWork.Commit();
        }

        public IEnumerable<UserTypeDTO> GetAllUserTypes()
        {
            return _mapper.Map<IEnumerable<UserType>, IEnumerable<UserTypeDTO>>(_unitOfWork.UserTypeRepository.Get());
        }

        public UserDTO GetUserByLoginAndPassword(string login, string passwd)
        {
            string passHash = Utils.ComputeSha256Hash(passwd);
            return _mapper.Map<UserDTO>(_unitOfWork.UserRepository.Get(u=>u.Login==login && u.PasswdHash == passHash).First());
        }

        public bool IsExistsUserByLoginAndPassword(string login, string passwd)
        {
            string passHash = Utils.ComputeSha256Hash(passwd);
            return _unitOfWork.UserRepository.Get(u => u.Login == login && u.PasswdHash == passHash ).Count() > 0;
        }

        public bool IsExistUserWithThisLogin(string login)
        {
            return _unitOfWork.UserRepository.Get(u => u.Login == login)?.ToList()?.Count() > 0;
        }
    }
}
