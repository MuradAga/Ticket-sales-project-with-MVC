using System.ComponentModel.DataAnnotations;

namespace KursProjectLast.Models
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Please enter username")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(4, ErrorMessage = "The password is short")]
        [MaxLength(12, ErrorMessage = "The password is long")]
        public string Password { get; set; }
    }
}
