﻿using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Invoice;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLCH_BE.Entities.Objects
{
    public class MembershipCardEntity : BaseEntity
    {
        public Guid? CardTypeId { get; set; }
        public CardTypeEntity CardType { get; set; }
        public string CustomerName { get; set; }

        public string? Phonenumber { get; set; }

        public string? Email { get; set; }

        public double? AccumulatedPoints { get; set; }

        public double? UsedPoints { get; set; }

        public decimal? AccumulatedAmount { get; set; }

        public decimal? UsedAmount { get; set; }

        public bool Gender { get; set; }
        public ICollection<InvoiceEntity> Invoices { get; set; }
        public MembershipCardEntity() { }
    }
}
