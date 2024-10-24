using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Invoice
{
    public class InvoiceDetailEntity : BaseEntity // Chi tiết hóa đơn
    {
        [ForeignKey(nameof(Invoice))]
        public Guid? InvoiceId { get; set; }
        public InvoiceEntity Invoice { get; set; }

        [ForeignKey(nameof(Product))]
        public Guid? ProductId { get; set; }
        public ProductEntity Product { get; set; }

        [ForeignKey(nameof(PurchaseInvoice))]
        public Guid? PurchaseOrderId { get; set; }
        public PurchaseInvoiceEntity PurchaseInvoice { get; set; }

        public decimal? Discount { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }
        public InvoiceDetailEntity() { }
    }
}
