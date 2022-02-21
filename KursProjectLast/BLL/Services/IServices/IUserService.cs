using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<UserToListDTO> Add(UserToAddDTO user);
        Task<bool> Check(UserLoginDTO user);
        Task<UserToListDTO> Get(int id);
    }
}
