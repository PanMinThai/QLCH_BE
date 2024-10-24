using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class InvoiceModel
    {
        [Key]
        public Guid InvoiceId { get; set; }
        public string? Note { get; set; }
    }
}
