using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly DataContext _dataContext;
        public PassengerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Passenger> Add(Passenger passenger)
        {
            await _dataContext.Passengers.AddAsync(passenger);
            await _dataContext.SaveChangesAsync();
            return passenger;
        }
    }
}
