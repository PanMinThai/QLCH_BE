using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Common
{
    public class BaseInvoiceEntity : BaseEntity
    {
        [ForeignKey(nameof(AppUserID))]
        public string AppUserID { get; set; }
        public AppUser appUser { get; set; }

        [ForeignKey(nameof(Brand))]
        public Guid? BranchId { get; set; }
        public BranchEntity Brand { get; set; }
        public DateTime time { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }

        public BaseInvoiceEntity() { }
    }
}
