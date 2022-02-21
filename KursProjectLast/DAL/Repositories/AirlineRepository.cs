using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProjectLast.DAL.Repositories
{
    public class AirlineRepository : IAirlineRepository
    {
        private readonly DataContext _dataContext;
        public AirlineRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Airline>> GetAirlines()
        {
            List<Airline> airlines = await _dataContext.Airlines.ToListAsync();
            return airlines;
        }
    }
}
