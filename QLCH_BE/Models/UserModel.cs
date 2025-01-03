namespace QLCH_BE.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Role { get; set; }
        public bool Isactive {  get; set; } 
    }
}
