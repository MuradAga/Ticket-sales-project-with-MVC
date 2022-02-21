using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface IFlightService
    {
        Task Add(FlightToAddDTO user);
        Task<List<FlightToListDTO>> GetFlights(int fromId, int toId, string departure);
        Task<FlightToListDTO> GetFlight(int? id);
    }
}
