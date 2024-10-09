namespace QLCH_BE.Entities
{
    public class InvoiceDetailEntity // Chi tiết hóa đơn
    {
        public Guid InvoiceDetailId { get; set; }

        public Guid? InvoiceId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? PurchaseOrderId { get; set; }

        public decimal? Discount { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? Notes { get; set; }
    }
}
