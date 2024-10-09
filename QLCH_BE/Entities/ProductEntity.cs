namespace QLCH_BE.Entities
{
    public class ProductEntity
    {
         public Guid Idproduct { get; set; } 

        public string? Idphoto{ get; set; }

        public string? Productname { get; set; }

        public decimal? Sellingprice { get; set; }

        public decimal? Costprice { get; set; }

        public string? Unit { get; set; }

        public int? Avaiablequatity { get; set; }

        public string? Notes { get; set; }
    }
}
