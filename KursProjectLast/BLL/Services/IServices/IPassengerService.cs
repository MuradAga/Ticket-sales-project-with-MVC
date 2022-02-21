using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface IPassengerService
    {
        Task<PassengerToListDTO> Add(PassengerToAddDTO passenger);
    }
}
