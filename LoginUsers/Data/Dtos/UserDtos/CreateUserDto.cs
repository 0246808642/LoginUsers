using System.ComponentModel.DataAnnotations;

namespace LoginUsers.Data.Dtos.UserDtos
{
    public class CreateUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
