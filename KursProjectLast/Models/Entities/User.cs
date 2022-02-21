using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KursProjectLast.Models.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please enter username")]
        public string UserName { get; set; }
        [MinLength(4, ErrorMessage = "The username is short")]
        [MaxLength(15, ErrorMessage = "The username is long")]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "The name is short")]
        [MaxLength(20, ErrorMessage = "The name is long")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(4, ErrorMessage = "The password is short")]
        public string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
