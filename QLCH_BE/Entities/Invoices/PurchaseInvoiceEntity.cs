using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Invoice
{
    public class PurchaseInvoiceEntity : BaseInvoiceEntity // Hóa đơn nhập hàng
    {
        public Guid SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; }

        public decimal? Discount { get; set; }

        public decimal? TotalAmountAfterDiscount { get; set; }

        public decimal? TotalAmountPayable { get; set; }
        public ICollection<InvoiceDetailEntity> InvoiceDetails { get; set; }
        public PurchaseInvoiceEntity() { }

        
    }
}
