using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Invoice;

namespace QLCH_BE.Entities.Objects
{
    public class SupplierEntity : BaseEntity// Nhà cung cấp
    {

        public string SupplierName { get; set; }

        public string RepresentativeName { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }

        public decimal? TotalPurchaseAmount { get; set; }

        public decimal? TotalAmountPaid { get; set; }
        public ICollection<PurchaseInvoiceEntity> PurchaseInvoices { get; set; }
        public SupplierEntity() { }
    }
}
