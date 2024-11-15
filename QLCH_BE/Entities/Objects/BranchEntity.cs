using QLCH_BE.Entities.Common;

namespace QLCH_BE.Entities.Objects
{
    public class BranchEntity :BaseEntity
    {
        public string BranchName { get; set; }

        public string Address { get; set; }
        public ICollection<EmployeeEntity> Employees { get; set; }
        public BranchEntity() { }
    }
}
