using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories.IRepositories
{
    public interface IAirlineRepository
    {
        Task<List<Airline>> GetAirlines();
    }
}
