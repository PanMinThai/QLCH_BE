
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class SupplierModel
    {
        [Key]
        public Guid SupplierId {  get; set; }
        public string SupplierName { get; set; }

        public string RepresentativeName { get; set; }

        public string Phonenumber { get; set; }

        public string Address { get; set; }

        public decimal? TotalPurchaseAmount { get; set; }

        public decimal? TotalAmountPaid { get; set; }
        public string? Note {  get; set; }
    }
}
