using QLCH_BE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class EmployeeEntity : BaseEntity
    {
        [ForeignKey(nameof(Branch))]
        public Guid? Idbranch { get; set; }
        public BranchEntity Branch { get; set; }
        [ForeignKey(nameof(AppUser))]
        public string? Idaccount { get; set; }
        public AppUser AppUser { get; set; }

        public string Nameemployee { get; set; }

        public string? Phonenumber { get; set; }

        public string? Startingdate { get; set; }

        public string? NationalIdcard { get; set; }

        public string? Dateofbirth { get; set; }

        public bool Gender { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }
        public EmployeeEntity() { }
    }
}
