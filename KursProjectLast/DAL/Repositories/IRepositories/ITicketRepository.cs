using KursProjectLast.Models.Entities;

namespace KursProjectLast.DAL.Repositories.IRepositories
{
    public interface ITicketRepository
    {
        Task<Ticket> Add(Ticket ticket);
        Task<List<Ticket>> GetTickets();
        Task<List<Ticket>> SearchTickets(string text);
        Task<Ticket> GetTicket(int? id);
    }
}
