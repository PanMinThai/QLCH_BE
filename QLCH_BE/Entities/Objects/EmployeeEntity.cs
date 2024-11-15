using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Invoice;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class EmployeeEntity : BaseEntity
    {
        public Guid? BranchId { get; set; }
        public BranchEntity Branch { get; set; }
        public Guid AppUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string NameEmployee { get; set; }

        public string? PhoneNumber { get; set; }

        public string? StartingDate { get; set; }

        public string? NationalIdcard { get; set; }

        public string? DateOfbirth { get; set; }

        public bool Gender { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Position { get; set; }
        public ICollection<ExpenseInvoiceEntity>? ExpenseInvoices { get; set; }
        public ICollection<InvoiceEntity>? Invoices { get; set; }
        public ICollection<PurchaseInvoiceEntity>? PurchaseInvoices { get; set; }
        public EmployeeEntity() { }
    }
}
