namespace QLCH_BE.Entities
{
    public class CardTypeEntity
    {
        public Guid CardTypeId { get; set; }

        public string? CardTypeName { get; set; }

        public string? Limit { get; set; }

        public string? Notes { get; set; }
    }
}
