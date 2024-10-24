using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class BranchModel
    {
        [Key]
        public Guid BranchId { get; set; }
        public string BranchName { get; set; }

        public string Address { get; set; }
        public string? Note { get; set; }

    }
}
