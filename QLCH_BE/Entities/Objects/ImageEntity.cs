using QLCH_BE.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class ImageEntity : BaseEntity
    {

        [NotMapped]
        public IFormFile File { get; set; }
        public ProductEntity Product { get; set; }
        public ImageEntity() { }
    }
}
