using KursProjectLast.DAL.DatabaseContext;
using KursProjectLast.DAL.Repositories.IRepositories;
using KursProjectLast.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace KursProjectLast.DAL.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _dataContext;
        public TicketRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Ticket> Add(Ticket ticket)
        {
            await _dataContext.Tickets.AddAsync(ticket);
            await _dataContext.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket> GetTicket(int? id)
        {
            Ticket ticket = _dataContext.Tickets.First(m => m.TicketId == id);
            return ticket;
        }

        public async Task<List<Ticket>> GetTickets()
        {
            List<Ticket> ticketList = await _dataContext.Tickets.Where(m => m.PassengerId != null).Include(m => m.Flight).Include(m => m.Passenger).OrderBy(m => m.Flight.Departure).ToListAsync();
            return ticketList;
        }

        public async Task<List<Ticket>> SearchTickets(string text)
        {
            List<Ticket> ticketList = await _dataContext.Tickets.Where(m => m.PassengerId != null && m.Passenger.FinCode.ToLower().Equals(text.ToLower())).Include(m => m.Flight).Include(m => m.Passenger).OrderBy(m => m.Flight.Departure).ToListAsync();
            return ticketList;
        }
    }
}
