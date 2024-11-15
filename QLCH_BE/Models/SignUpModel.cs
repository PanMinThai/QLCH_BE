using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}
