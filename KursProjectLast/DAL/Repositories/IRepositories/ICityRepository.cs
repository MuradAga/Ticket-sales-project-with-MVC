using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories.IRepositories
{
    public interface ICityRepository
    {
        Task<List<City>> GetCities();
    }
}
