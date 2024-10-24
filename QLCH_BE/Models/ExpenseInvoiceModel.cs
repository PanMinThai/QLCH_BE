using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class ExpenseInvoiceModel
    {
        [Key]
        public Guid ExpenseInvoiceId { get; set; }
        public string? ExpenseInvoiceName { get; set; }

        public decimal? ExpenseAmount { get; set; }
        public string? Note { get; set; }
    }
}
