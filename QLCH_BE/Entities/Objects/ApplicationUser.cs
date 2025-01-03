using Microsoft.AspNetCore.Identity;
using QLCH_BE.Entities.Invoice;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class ApplicationUser: IdentityUser<Guid>
    {
        public string Name {  get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public EmployeeEntity? Employee { get; set; }

        public string Phone { get; set; }

        public ApplicationUser()
        {
            CreatedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
        }
    }
}
