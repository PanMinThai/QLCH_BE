using QLCH_BE.Entities.Invoice;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class InvoiceDetailModel
    {
        [Key]
        public Guid InvoiceDetalId { get; set; }
        public Guid? InvoiceId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? PurchaseOrderId { get; set; }

        public decimal? Discount { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? TotalAmount { get; set; }
        public string? Note { get; set; }
    }
}
