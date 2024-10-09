namespace QLCH_BE.Entities
{
    public class SupplierEntities // Nhà cung cấp
    {
        public Guid Idsupplier{ get; set; }

        public string? SupplierName { get; set; }

        public string? RepresentativeName { get; set; }

        public string? Phonenumber { get; set; }

        public string? Address { get; set; }

        public decimal? TotalPurchaseAmount { get; set; }

        public decimal? TotalAmountPaid { get; set; }

        public string? Note { get; set; }
    }
}
