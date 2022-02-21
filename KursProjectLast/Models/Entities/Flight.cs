using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursProjectLast.Models.Entities
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }
        [Required(ErrorMessage = "Please enter the number of places")]
        public int? NumberOfPlace { get; set; }
        public string? Departure { get; set; }
        public virtual City? From { get; set; }
        [ForeignKey("From")]
        public int? FromId { get; set; }
        public virtual City? To { get; set; }
        [ForeignKey("To")]
        public int? ToId { get; set; }
        public virtual Airline? Airline { get; set; }
        [ForeignKey("Airline")]
        public int? AirlineId { get; set; }
        public float? Price { get; set; }
    }
}
