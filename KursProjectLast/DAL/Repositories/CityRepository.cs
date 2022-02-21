using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProjectLast.DAL.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;
        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<City>> GetCities()
        {
            List<City> cities = await _dataContext.Cities.ToListAsync();
            return cities;
        }
    }
}
