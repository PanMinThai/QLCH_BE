using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Invoice
{
    public class InvoiceEntity :BaseInvoiceEntity
    {
        [ForeignKey(nameof(MembershipCard))]
        public Guid? MembershipCardId { get; set; }
        public MembershipCardEntity MembershipCard { get; set; }
        public decimal Discount {  get; set; }
        public decimal PayableAmount { get; set; }
        public ICollection<InvoiceDetailEntity> InvoiceDetails { get; set; }
        public InvoiceEntity() { }
    }
}
