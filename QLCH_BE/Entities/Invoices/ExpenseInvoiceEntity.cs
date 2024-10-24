using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Invoice
{
    public class ExpenseInvoiceEntity : BaseInvoiceEntity// Hóa đơn chi tiêu
    {

        public string? ExpenseInvoiceName { get; set; }

        public decimal? ExpenseAmount { get; set; }

        public ExpenseInvoiceEntity() { }
    }
}
