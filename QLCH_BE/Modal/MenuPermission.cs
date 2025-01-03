namespace QLCH_BE.Modal
{
    public class MenuPermission
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool HaveView { get; set; }
        public bool HaveAdd { get; set; }
        public bool HaveEdit { get; set; }
        public bool HaveDelete { get; set; }
    }
}
