namespace QLCH_BE.Models.AccountManagement
{
    public class ConfirmPassword
    {
        public Guid Userid { get; set; }
        public string UserName { get; set; }
        public string otptext { get; set; }
    }
}
