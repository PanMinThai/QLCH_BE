using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Entities.AccountManagement
{
    public class OtpManager
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string Otptext { get; set; } = null!;
        public string? Otptype { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
