using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        public PassengerService(IPassengerRepository passengerRepository, IMapper mapper1)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper1;
        }

        public async Task<PassengerToListDTO> Add(PassengerToAddDTO passenger)
        {
            Passenger addPassenger = _mapper.Map<Passenger>(passenger);
            Passenger addedPassenger = await _passengerRepository.Add(addPassenger);
            return _mapper.Map<PassengerToListDTO>(addedPassenger);
        }
    }
}
