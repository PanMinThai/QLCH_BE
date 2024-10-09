namespace QLCH_BE.Entities
{
    public class ExpenseReceiptEntity // Hóa đơn chi tiêu
    {
        public Guid ExpenseReceiptId { get; set; }

        public Guid? EmployeeId { get; set; }

        public Guid? BranchId { get; set; }

        public string? ExpenseReceiptName { get; set; }

        public decimal? ExpenseAmount { get; set; }

        public DateTime? ReceiptCreationTime { get; set; }

        public string? Notes { get; set; }
    }
}
