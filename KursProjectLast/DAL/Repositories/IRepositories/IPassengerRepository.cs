using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories.IRepositories
{
    public interface IPassengerRepository
    {
        Task<Passenger> Add(Passenger passenger);
    }
}
