using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KursProjectLast.Models.Entities
{
    public class Airline
    {
        [Key]
        public int AirlineId { get; set; }
        [Required(ErrorMessage = "The name of the airline can't be empty")]
        public string AirlineName { get; set; }
    }
}
