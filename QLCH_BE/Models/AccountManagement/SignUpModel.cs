using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models.AccountManagement
{
    public class SignUpModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        [Required, EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
        [Required]
        public string Phone { get; set; } = null!;
    }
}
