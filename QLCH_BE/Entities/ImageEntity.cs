namespace QLCH_BE.Entities
{
    public class ImageEntity
    {
        public Guid ImageId { get; set; } 

        public string? ImageFile { get; set; } 

        public string? Notes { get; set; } 

        public IFormFile? File { get; set; } 
    }
}
