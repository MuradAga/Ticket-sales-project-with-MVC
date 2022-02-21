using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursProjectLast.Models.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public virtual Flight Flight { get; set; }
        [ForeignKey("Flight")]
        public int FlightId { get; set; }
        public virtual Passenger? Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int? PassengerId { get; set; }
    }
}
