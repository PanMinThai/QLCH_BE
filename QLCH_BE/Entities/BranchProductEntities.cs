﻿namespace QLCH_BE.Entities
{
    public class BranchProductEntities
    {
        public Guid ProductId { get; set; }

        public Guid BranchId { get; set; }

        public string? Notes { get; set; }
    }
}
