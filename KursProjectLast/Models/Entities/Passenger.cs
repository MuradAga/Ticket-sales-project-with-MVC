using System.ComponentModel.DataAnnotations;

namespace KursProjectLast.Models.Entities
{
    public class Passenger
    {
        [Key]
        public int? PassengerId { get; set; }
        [Required(ErrorMessage = "Please enter Fin Code")]
        [MinLength(7, ErrorMessage = "You entered incorrectly")]
        [MaxLength(7, ErrorMessage = "You entered incorrectly")]
        public string? FinCode { get; set; }
        [MinLength(4, ErrorMessage = "The username is short")]
        [MaxLength(15, ErrorMessage = "The username is long")]
        public string? Name { get; set; }
        [MinLength(2, ErrorMessage = "The name is short")]
        [MaxLength(20, ErrorMessage = "The name is long")]
        public string? Surname { get; set; }
        [MinLength(10, ErrorMessage = "The name is short")]
        [MaxLength(20, ErrorMessage = "The name is long")]
        public string? PhoneNumber { get; set; }

    }
}
