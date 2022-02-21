using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository _airlineRepository;
        private readonly IMapper _mapper;
        public AirlineService(IAirlineRepository airlineRepository, IMapper mapper)
        {
            _airlineRepository = airlineRepository; ;
            _mapper = mapper;
        }
        public async Task<List<AirlineToListDTO>> GetAirlines()
        {
            List<Airline> airlines = await _airlineRepository.GetAirlines();
            return _mapper.Map<List<AirlineToListDTO>>(airlines);
        }
    }
}
