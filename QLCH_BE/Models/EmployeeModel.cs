using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public Guid? Idbranch { get; set; }
        public string? Idaccount { get; set; }

        public string NameEmployee { get; set; }

        public string? Phonenumber { get; set; }

        public string? Startingdate { get; set; }

        public string? NationalIdcard { get; set; }

        public string? Dateofbirth { get; set; }

        public bool Gender { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }
        public string? Note {  get; set; }
    }
}
