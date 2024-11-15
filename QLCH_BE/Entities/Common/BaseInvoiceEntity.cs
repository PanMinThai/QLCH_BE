using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Common
{
    public class BaseInvoiceEntity : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
        public Guid? BranchId { get; set; }
        public BranchEntity Brand { get; set; }
        public DateTime Time { get; set; }
        public double TotalAmount { get; set; }
        public string? Notes { get; set; }

        public BaseInvoiceEntity() { }
    }
}
