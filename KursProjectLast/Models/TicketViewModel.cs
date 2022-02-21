using KursProjectLast.Models.Entities;

namespace KursProjectLast.Models
{
    public class TicketViewModel
    {
        public FlightToListDTO Flight { get; set; }
        public PassengerToListDTO? Passenger { get; set; }
        public int FlightId { get; set; }
        public int NumberOfPlace { get; set; }
        public string Departure { get; set; }
        public virtual City? From { get; set; }
        public int FromId { get; set; }
        public virtual City? To { get; set; }
        public int ToId { get; set; }
        public virtual Airline? Airline { get; set; }
        public int? AirlineId { get; set; }
        public float Price { get; set; }
        public int? PassengerId { get; set; }
        public string? FinCode { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
