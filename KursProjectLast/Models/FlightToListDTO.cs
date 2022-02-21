using KursProjectLast.Models.Entities;

namespace KursProjectLast.Models
{
    public class FlightToListDTO
    {
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
    }
}
