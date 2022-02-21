using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserToListDTO> Add(UserToAddDTO user)
        {
            User addUser = _mapper.Map<User>(user);
            User addedUser = await _userRepository.Add(addUser);
            return _mapper.Map<UserToListDTO>(addedUser);
        }

        public async Task<bool> Check(UserLoginDTO user)
        {
            User user1 = _mapper.Map<User>(user);
            return await _userRepository.Check(user1);
        }

        public async Task<UserToListDTO> Get(int id)
        {
            User user = await _userRepository.Get(id);
            return _mapper.Map<UserToListDTO>(user);
        }
    }
}
