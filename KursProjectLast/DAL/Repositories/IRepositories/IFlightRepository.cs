using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories.IRepositories
{
    public interface IFlightRepository
    {
        Task Add(Flight flight);
        Task<List<Flight>> GetFlights(int fromId, int toId, string departure);
        Task<Flight> GetFlight(int? id);
    }
}
