using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Entities.AccountManagement
{
    public class PwdManager
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? ModifyDate { get; set; }
    }
}
