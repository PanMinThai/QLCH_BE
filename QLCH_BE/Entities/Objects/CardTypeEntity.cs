using QLCH_BE.Entities.Common;

namespace QLCH_BE.Entities.Objects
{
    public class CardTypeEntity : BaseEntity
    {
        public string CardTypeName { get; set; }

        public string Limit { get; set; }
        public ICollection<MembershipCardEntity> Membershipcard {  get; set; }
        public CardTypeEntity() { }
    }
}
