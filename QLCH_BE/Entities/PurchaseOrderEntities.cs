namespace QLCH_BE.Entities
{
    public class PurchaseOrderEntities
    {
        public Guid PurchaseOrderId { get; set; }
        public Guid EmployeeId { get; set; }

        public Guid? SupplierId { get; set; }

        public Guid? BranchId { get; set; }

        public string? ProductName { get; set; }

        public decimal? Discount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountPayable { get; set; }

        public DateTime? InvoiceCreationTime { get; set; }

        public string? Notes { get; set; }
    }
}
