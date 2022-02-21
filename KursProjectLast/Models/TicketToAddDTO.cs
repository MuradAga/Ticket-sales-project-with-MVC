using KursProjectLast.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace KursProjectLast.Models
{
    public class TicketToAddDTO
    {
        public int TicketId { get; set; }
        public virtual Flight Flight { get; set; }
        public int FlightId { get; set; }
        public virtual Passenger? Passenger { get; set; }
        public int? PassengerId { get; set; }
    }
}
