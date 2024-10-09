namespace QLCH_BE.Entities
{
    public class EmployeeEntities
    {
        public Guid Idemployee { get; set; }

        public Guid? Idbranch { get; set; }

        public Guid? Idaccount { get; set; }

        public string? Nameemployee { get; set; }

        public string? Phonenumber { get; set; }

        public string? Startingdate { get; set; }

        public string? NationalIdcard { get; set; }

        public string? Dateofbirth { get; set; }

        public bool? Gender { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }

        public string? Notes { get; set; }
    }
}
