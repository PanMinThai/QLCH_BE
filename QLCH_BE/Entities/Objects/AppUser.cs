using Microsoft.AspNetCore.Identity;
using QLCH_BE.Entities.Invoice;

namespace QLCH_BE.Entities.Objects
{
    public class AppUser: IdentityUser
    {
        public string Name {  get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public ICollection<ExpenseInvoiceEntity>? ExpenseInvoices { get; set; }
        public ICollection<InvoiceEntity>? Invoices { get; set; }
        public ICollection<PurchaseInvoiceEntity>? PurchaseInvoices { get;set; }
        public AppUser()
        {
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }
    }
}
