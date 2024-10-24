using QLCH_BE.Entities.Objects;
using System.ComponentModel.DataAnnotations;

namespace QLCH_BE.Models
{
    public class MembershipCardModel
    {
        [Key]
        public Guid MembershipCardId { get; set; }
        public Guid CardTypeId { get; set; }
        public string CustomerName { get; set; }

        public string? Phonenumber { get; set; }

        public string? Email { get; set; }

        public double? AccumulatedPoints { get; set; }

        public double? UsedPoints { get; set; }

        public decimal? AccumulatedAmount { get; set; }

        public decimal? UsedAmount { get; set; }

        public bool Gender { get; set; }
        public string? Note { get; set; }
    }
}
