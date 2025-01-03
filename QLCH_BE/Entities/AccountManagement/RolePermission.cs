using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QLCH_BE.Entities.AccountManagement
{
    //public class RolePermission
    //{
    //    public Guid Id { get; set; }
    //    public string UserRole { get; set; } = null!;
    //    public string MenuCode { get; set; } = null!;
    //    public bool HaveView { get; set; }
    //    public bool HaveAdd { get; set; }
    //    public bool HaveEdit { get; set; }
    //    public bool HaveDelete { get; set; }
    //}
    public class RolePermission
    {
        [Key]
        public Guid Id { get; set; }

        public Guid RoleId { get; set; } //  AspNetRoles

        public Guid MenuId { get; set; } //  Menu

        public bool HaveView { get; set; }
        public bool HaveAdd { get; set; }
        public bool HaveEdit { get; set; }
        public bool HaveDelete { get; set; }

        [ForeignKey(nameof(RoleId))]
        public IdentityRole<Guid>? Role { get; set; }

        [ForeignKey(nameof(MenuId))]
        public Menu? Menu { get; set; }
    }

}
