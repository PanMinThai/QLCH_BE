using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class ImageModel
    {
        [Key]
        public Guid ImageId { get; set; }
        public string Name { get; set; }
        public IFormFile File { get; set; }
    }
}
