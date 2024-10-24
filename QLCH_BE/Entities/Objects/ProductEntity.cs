using QLCH_BE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class ProductEntity : BaseEntity
    {
        [ForeignKey(nameof(Image))]
        public Guid? ImageId { get; set; }
        public ImageEntity? Image { get; set; }

        public string Productname { get; set; }

        public decimal? Sellingprice { get; set; }

        public decimal? Costprice { get; set; }

        public string Unit { get; set; }

        public int? Avaiablequatity { get; set; }
        public ProductEntity() { }
    }
}
