using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;
        public CityService(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }
        public async Task<List<CityToListDTO>> GetCities()
        {
            List<City> cities = await _cityRepository.GetCities();
            return _mapper.Map<List<CityToListDTO>>(cities);
        }
    }
}
