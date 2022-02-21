using KursProjectLast.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursProjectLast.Models
{
    public class FlightToAddDTO
    {
        public int? NumberOfPlace { get; set; }
        public string? Departure { get; set; }
        public int? FromId { get; set; }
        public int? ToId { get; set; }
        public int? AirlineId { get; set; }
        public float? Price { get; set; }
    }
}
