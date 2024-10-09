namespace QLCH_BE.Entities.Invoice
{
    public class ExpenseInvoiceEntity // Hóa đơn chi tiêu
    {
        public Guid ExpenseInvoiceId { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? BranchId { get; set; }

        public string? ExpenseInvoiceName { get; set; }

        public decimal? ExpenseAmount { get; set; }

        public DateTime? InvoiceCreationTime { get; set; }

        public string? Notes { get; set; }
    }
}
