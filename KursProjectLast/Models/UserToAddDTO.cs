using System.ComponentModel.DataAnnotations;

namespace KursProjectLast.Models
{
    public class UserToAddDTO
    {
        [Required(ErrorMessage = "Please enter username")]
        [MinLength(4, ErrorMessage = "The username is short")]
        [MaxLength(15, ErrorMessage = "The username is long")]
        public string? UserName { get; set; }
        [MinLength(3, ErrorMessage = "The name is short")]
        [MaxLength(20, ErrorMessage = "The name is long")]
        public string? Name { get; set; }
        [MinLength(3, ErrorMessage = "The surnname is short")]
        [MaxLength(30, ErrorMessage = "The surname is long")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(4, ErrorMessage = "The password is short")]
        [MaxLength(12, ErrorMessage = "The password is long")]
        public string? Password { get; set; }
    }
}
