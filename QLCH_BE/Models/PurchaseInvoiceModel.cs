using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class PurchaseInvoiceModel
    {
        [Key]
        public Guid Id { get; set; }

        public string? Note { get; set; }
    }
}
