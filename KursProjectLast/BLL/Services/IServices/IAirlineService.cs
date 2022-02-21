using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface IAirlineService
    {
        Task<List<AirlineToListDTO>> GetAirlines();
    }
}
