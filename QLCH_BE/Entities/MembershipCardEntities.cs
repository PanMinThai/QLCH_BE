namespace QLCH_BE.Entities
{
    public class MembershipCardEntities
    {
        public Guid MembershipCardId { get; set; }

        public Guid? CardTypeId { get; set; }
        public string? CustomernName { get; set; }

        public string? Phonenumber { get; set; }

        public string? Email { get; set; }

        public double? AccumulatedPoints { get; set; }

        public double? UsedPoints { get; set; }

        public decimal? AccumulatedAmount { get; set; }

        public decimal? UsedAmount { get; set; }

        public bool? Gender { get; set; }

        public string? Address { get; set; }

        public string? Notes { get; set; }
    }
}
