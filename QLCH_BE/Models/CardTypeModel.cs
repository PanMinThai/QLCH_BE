using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class CardTypeModel
    {
        [Key]
        public Guid CardTypeId { get; set; }
        public string CardTypeName { get; set; }

        public string Limit { get; set; }
        public string? Note {  get; set; }
    }
}
