namespace QLCH_BE.Entities
{
    public class ExpenditureVoucherEntities
    {
        public Guid ExpenditureVoucherId { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? BranchId { get; set; }

        public string? ExpenditureVoucherName { get; set; }

        public decimal? ExpenditureAmount { get; set; }

        public DateTime? VoucherCreationTime { get; set; }

        public string? Notes { get; set; }
    }
}
