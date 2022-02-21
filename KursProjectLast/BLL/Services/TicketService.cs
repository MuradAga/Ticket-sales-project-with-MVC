
using AutoMapper;
using KursProjectLast.BLL.Services.IServices;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models;
using KursProjectLast.Models.Entities;

namespace KursProjectLast.BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketToListDTO> Add(TicketToAddDTO ticket)
        {
            Ticket addTicket = _mapper.Map<Ticket>(ticket);
            Ticket addedTicket = await _ticketRepository.Add(addTicket);
            Flight flight = await _flightRepository.GetFlight(ticket.FlightId);
            flight.NumberOfPlace -= 1;
            return _mapper.Map<TicketToListDTO>(addedTicket);
        }

        public async Task<TicketToListDTO> GetTicket(int? id)
        {
            Ticket ticket = await _ticketRepository.GetTicket(id);
            return _mapper.Map<TicketToListDTO>(ticket);
        }

        public async Task<List<TicketToListDTO>> GetTickets()
        {
            List<Ticket> tickets = await _ticketRepository.GetTickets();
            return _mapper.Map<List<TicketToListDTO>>(tickets);
        }

        public async Task<List<TicketToListDTO>> SearchTickets(string text)
        {
            List<Ticket> tickets = await _ticketRepository.SearchTickets(text);
            return _mapper.Map<List<TicketToListDTO>>(tickets);
        }
    }
}
