namespace QLCH_BE.Modal
{
    public class RolePermissionModel
    {
        public Guid Id { get; set; } 
        public Guid RoleId { get; set; } 
        public Guid MenuId { get; set; }
        public bool HaveView { get; set; } 
        public bool HaveAdd { get; set; }
        public bool HaveEdit { get; set; } 
        public bool HaveDelete { get; set; } 
    }

}
