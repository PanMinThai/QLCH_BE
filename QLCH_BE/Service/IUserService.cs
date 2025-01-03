using QLCH_BE.Helper;
using QLCH_BE.Models;
using QLCH_BE.Models.AccountManagement;

namespace QLCH_BE.Service
{
    public interface IUserService
    {
        Task<APIResponse> ConfirmRegister(Guid userid, string username, string otptext);
        Task<APIResponse> UserRegisteration(SignUpModel model);
        Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword);
        Task<APIResponse> ForgetPassword(string username);
        Task<APIResponse> UpdatePassword(string username, string Password, string Otptext);
        Task<APIResponse> UpdateStatus(string username, bool userstatus);
        Task<APIResponse> UpdateRole(string username, string userrole);
        Task<List<UserModel>> Getall();
        Task<UserModel> Getbycode(string code);
    }
}
