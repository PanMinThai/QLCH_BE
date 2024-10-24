using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class ProductModel
    {
        [Key]
        public Guid  ProductId { get; set; }
        public Guid? IdImage { get; set; }
        public string Productname { get; set; }

        public decimal? Sellingprice { get; set; }

        public decimal? Costprice { get; set; }

        public string Unit { get; set; }

        public int? Avaiablequatity { get; set; }
        public string? Note { get; set; }
    }
}
