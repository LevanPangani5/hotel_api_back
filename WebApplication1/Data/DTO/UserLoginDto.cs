using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data.DTO
{
    public class UserLoginDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
