namespace QLCH_BE.Entities
{
    public class BranchEntity
    {
        public Guid BranchId { get; set; }

        public string? BranchName { get; set; }

        public string? Address { get; set; }

        public string? Phonenumber { get; set; }

        public string? Notes { get; set; }
    }
}
