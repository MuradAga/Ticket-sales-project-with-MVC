using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface ICityService
    {
        Task<List<CityToListDTO>> GetCities();
    }
}
