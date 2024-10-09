namespace QLCH_BE.Entities.Invoice
{
    public class InvoiceEntity
    {
        public Guid InvoiceId { get; set; }

        public Guid? BranchId { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? MemberId { get; set; }

        public string? InvoiceDate { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public string? Notes { get; set; }
    }
}
