using System.ComponentModel.DataAnnotations;

namespace LoginUsers.Data.Dtos.UserDtos;

public class LoginUserDto
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}
