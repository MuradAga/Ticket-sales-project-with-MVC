using KursProjectLast.Models.Entities;

namespace KursProjectLast.Models
{
    public class TicketToListDTO
    {
        public int TicketId { get; set; }
        public virtual FlightToListDTO? Flight { get; set; }
        public int FlightId { get; set; }
        public virtual PassengerToListDTO? Passenger { get; set; }
        public int? PassengerId { get; set; }
    }
}
