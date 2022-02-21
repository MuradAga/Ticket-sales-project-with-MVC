using KursProjectLast.Models;

namespace KursProjectLast.BLL.Services.IServices
{
    public interface ITicketService
    {
        Task<TicketToListDTO> Add(TicketToAddDTO ticket);
        Task<List<TicketToListDTO>> GetTickets();
        Task<List<TicketToListDTO>> SearchTickets(string text);
        Task<TicketToListDTO> GetTicket(int? id);
    }
}
