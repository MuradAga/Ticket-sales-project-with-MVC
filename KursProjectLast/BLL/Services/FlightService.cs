using AutoMapper;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services.IServices
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public FlightService(IFlightRepository flightRepository, IMapper mapper1)
        {
            _flightRepository = flightRepository;
            _mapper = mapper1;
        }
        public async Task Add(FlightToAddDTO flight)
        {
            Flight addFlight = _mapper.Map<Flight>(flight);
            await _flightRepository.Add(addFlight);
        }

        public async Task<FlightToListDTO> GetFlight(int? id)
        {
            Flight flight = await _flightRepository.GetFlight(id);
            return _mapper.Map<FlightToListDTO>(flight);
        }

        public async Task<List<FlightToListDTO>> GetFlights(int fromId, int toId, string departure)
        {
            if(fromId == 0 && toId == 0 && departure == null)
            {
                List<Flight> flights = await _flightRepository.GetFlights(fromId, toId, departure);
                return _mapper.Map<List<FlightToListDTO>>(flights);
            }
            else if (departure != null)
            {
                departure = departure.Substring(5, 2) + "/" + departure.Substring(8, 2) + "/" + departure.Substring(0, 4);
                List<Flight> flights = await _flightRepository.GetFlights(fromId, toId, departure);
                return _mapper.Map<List<FlightToListDTO>>(flights);
            }
            else
            {
                List<Flight> flights = await _flightRepository.GetFlights(fromId, toId, departure);
                return _mapper.Map<List<FlightToListDTO>>(flights);
            }
        }
    }
}