namespace QLCH_BE.Models.AccountManagement
{
    public class ResetPassword
    {
        public string UserName { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
