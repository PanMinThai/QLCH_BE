namespace QLCH_BE.Models.AccountManagement
{
    public class UpdatePassword
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string OtpText { get; set; }
    }
}
