using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProjectLast.DAL.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly DataContext _dataContext;
        private readonly ITicketRepository _ticketRepository;

        public FlightRepository(DataContext dataContext, ITicketRepository ticketRepository)
        {
            _dataContext = dataContext;
            _ticketRepository = ticketRepository;
        }
        public async Task Add(Flight flight)
        {
            await _dataContext.Flights.AddAsync(flight);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Flight> GetFlight(int? id)
        {
            Flight flight = _dataContext.Flights.First(m => m.FlightId == id);
            return flight;
        }

        public async Task<List<Flight>> GetFlights(int fromId, int toId, string departure)
        {
            if (fromId == 0 && toId == 0 && departure == null)
            {
                List<Flight> flightList = await _dataContext.Flights.Include(m => m.From).Include(m => m.To).Include(m => m.Airline).ToListAsync();
                return flightList;
            }
            else if (departure != null)
            {
                List<Flight> flightList = await _dataContext.Flights.Where(m => m.From.CityId == fromId && m.To.CityId == toId && m.Departure.Substring(0, 10) == departure).Include(m => m.From).Include(m => m.To).Include(m => m.Airline).ToListAsync();
                return flightList;
            }
            else
            {
                List<Flight> flightList = await _dataContext.Flights.Where(m => m.From.CityId == fromId && m.To.CityId == toId).Include(m => m.From).Include(m => m.To).Include(m => m.Airline).ToListAsync();
                return flightList;
            }
        }
    }
}
