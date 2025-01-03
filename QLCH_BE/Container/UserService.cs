using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using QLCH_BE.Entities.AccountManagement;
using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Helper;
using QLCH_BE.Modal;
using QLCH_BE.Models;
using QLCH_BE.Models.AccountManagement;
using QLCH_BE.Service;
using System.Security;

namespace QLCH_BE.Container
{
    public class UserService : IUserService
    {
        private readonly StoreManagementDbContext _context;
        private readonly IMapper _mapper;    
        private readonly IEmailService emailService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(StoreManagementDbContext learndata, IMapper mapper, IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _context = learndata;
            _mapper = mapper;
            this.emailService = emailService;
            _userManager = userManager;
        }

        public async Task<APIResponse> ConfirmRegister(Guid userid, string username, string otptext)
        {
            APIResponse response = new APIResponse();
            bool otpresponse = await ValidateOTP(username, otptext);
            if (!otpresponse)
            {
                response.Result = "fail";
                response.Message = "Invalid OTP or Expired";
            }
            else
            {
                List<TemporaryUser> list = _context.TemporaryUsers.ToList();
                var _tempdata = await this._context.TemporaryUsers.FirstOrDefaultAsync(item => item.Id == userid);
                var _user = new ApplicationUser()
                {
                    UserName = username,
                    Name = _tempdata.Name,
                    Email = _tempdata.Email,
                    Phone = _tempdata.Phone,
                    AccessFailedCount = 0,
                    NormalizedEmail = _tempdata.Email.ToUpperInvariant(),
                    EmailConfirmed   = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                
                // hash pwd
                var passwordHasher = new PasswordHasher<ApplicationUser>();
                _user.PasswordHash = passwordHasher.HashPassword(_user, _tempdata.Password);

                await this._context.ApplicationUsers.AddAsync(_user);
                await this._context.SaveChangesAsync();
                await UpdatePWDManager(username, _tempdata.Password);
                await _userManager.AddToRoleAsync(_user, ApplicationRole.Employee);// gans role luon            // ****
                response.Result = "pass";
                response.Message = "Registered successfully.";
            }

            return response;
        }

        public async Task<APIResponse> UserRegisteration(SignUpModel model)
        {
            APIResponse response = new APIResponse();
            Guid userid;
            bool isvalid = true;
            //Console.WriteLine(model.UserName + "\t" + model.Name + "\t" + model.Email + "\t" + model.Password + "\t" + model.Phone);
            try
            {
                var _user = await this._context.ApplicationUsers.Where(item => item.UserName == model.Email).ToListAsync();
                if (_user.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.Message = "Duplicate username";
                }

                var _useremail = await this._context.ApplicationUsers.Where(item => item.Email == model.Email).ToListAsync();
                if (_useremail.Count > 0)
                {
                    isvalid = false;
                    response.Result = "fail";
                    response.Message = "Duplicate Email";
                }              

                if (model != null && isvalid)
                {
                    var _tempuser = new TemporaryUser()
                    {
                        Code = model.UserName,
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Phone = model.Phone,
                    };
                    await this._context.TemporaryUsers.AddAsync(_tempuser);
                    await this._context.SaveChangesAsync();
                    userid = _tempuser.Id;
                    string OTPText = Generaterandomnumber();
                    await UpdateOtp(model.UserName, OTPText, "register");
                   // await SendOtpMail(model.Email, OTPText, model.Name); // lỗi mail 
                    response.Result = "pass"; // tạm thời
                    response.Message = userid.ToString();
                }
            }
            catch (Exception ex)
            {
                response.Result = "fail";
            }

            return response;
        }

        public async Task<APIResponse> ResetPassword(string username, string oldpassword, string newpassword)
        {
            APIResponse response = new APIResponse();
            // Tìm người dùng dựa trên username
            var _user = await _userManager.FindByNameAsync(username);

            if (_user != null)
            {
                string old_pwd_hash = BCrypt.Net.BCrypt.HashPassword(oldpassword);
                // Kiểm tra mật khẩu cũ có chính xác không (Identity sẽ tự động so sánh mật khẩu đã băm)
                bool passwordCheck = await _userManager.CheckPasswordAsync(_user, oldpassword);

                if (passwordCheck)
                {
                    // Nếu mật khẩu cũ chính xác, bạn có thể tiếp tục thay đổi mật khẩu
                    bool passwordHistoryCheck = await Validatepwdhistory(username, newpassword);
                    if (passwordHistoryCheck)
                    {
                        response.Result = "fail";
                        response.Message = "Don't use the same password that used in last 3 transactions.";
                    }
                    else
                    {
                        // Cập nhật mật khẩu mới
                        var passwordChangeResult = await _userManager.ChangePasswordAsync(_user, oldpassword, newpassword);

                        if (passwordChangeResult.Succeeded)
                        {
                            await UpdatePWDManager(username, newpassword);
                            response.Result = "pass";
                            response.Message = "Password changed successfully.";
                        }
                        else
                        {
                            response.Result = "fail";
                            response.Message = "Password change failed.";
                        }
                    }
                }
                else
                {
                    response.Result = "fail";
                    response.Message = "Incorrect old password.";
                }
            }
            else
            {
                response.Result = "fail";
                response.Message = "User not found.";
            }

            return response;
        }

        public async Task<APIResponse> ForgetPassword(string username)
        {
            APIResponse response = new APIResponse();
            var _user = await this._context.ApplicationUsers.FirstOrDefaultAsync(item => item.UserName == username && item.EmailConfirmed == true);
            if (_user != null)
            {
                string otptext = Generaterandomnumber();
                await UpdateOtp(username, otptext, "forgetpassword");
               // await SendOtpMail(_user.Email, otptext, _user.Name); gửi mail lỗi
                response.Result = "pass";
                response.Message = "OTP sent";
            }
            else
            {
                response.Result = "fail";
                response.Message = "Invalid User";
            }
            return response;
        }

        public async Task<APIResponse> UpdatePassword(string username, string password, string otpText)
        {
            APIResponse response = new APIResponse();

            // Kiểm tra OTP
            bool otpValidation = await ValidateOTP(username, otpText);
            if (!otpValidation)
            {
                response.Result = "fail";
                response.Message = "Invalid OTP";
                return response;
            }

            // Kiểm tra lịch sử mật khẩu
            bool pwdHistory = await Validatepwdhistory(username, password);
            if (pwdHistory)
            {
                response.Result = "fail";
                response.Message = "Don't use the same password that was used in the last 3 transactions.";
                return response;
            }

            // Lấy thông tin người dùng
            var _user = await this._context.ApplicationUsers.FirstOrDefaultAsync(item => item.UserName == username && item.EmailConfirmed == true);
            if (_user == null)
            {
                response.Result = "fail";
                response.Message = "User not found or inactive.";
                return response;
            }

            // hash pưd
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            _user.PasswordHash = passwordHasher.HashPassword(_user, password);

            // Lưu thay đổi
            await this._context.SaveChangesAsync();
            await UpdatePWDManager(username, password);
            response.Result = "pass";
            response.Message = "Password changed successfully.";
            return response;
        }
        public async Task<APIResponse> UpdateRole(string username, string userrole)
        {
            APIResponse response = new APIResponse();
            var _user = await this._context.ApplicationUsers.FirstOrDefaultAsync(item => 
            item.UserName == username && item.EmailConfirmed == true);

            if (_user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(_user);

                // Xóa vai trò cũ nếu có
                foreach (var role in userRoles)
                    await _userManager.RemoveFromRoleAsync(_user, role);
                // Thêm vai trò mới
                var addRoleResult = await _userManager.AddToRoleAsync(_user, userrole);
                if (addRoleResult.Succeeded)
                {
                    response.Result = "pass";
                    response.Message = "User role updated successfully.";
                }
                else
                {
                    response.Result = "fail";
                    response.Message = "Failed to update user role.";
                }
            }
            else
            {
                response.Result = "fail";
                response.Message = "Invalid user.";
            }

            return response;
        }


        private async Task UpdateOtp(string username, string otptext, string otptype)
        {
            var _opt = new OtpManager()
            {
                UserName = username,
                Otptext = otptext,
                Expiration = DateTime.Now.AddMinutes(30),
                CreatedDate = DateTime.Now,
                Otptype = otptype
            };
            await this._context.OtpManagers.AddAsync(_opt);
            await this._context.SaveChangesAsync();
        }

        private async Task<bool> ValidateOTP(string username, string OTPText)
        {
            bool response = false;
            var _data = await this._context.OtpManagers.FirstOrDefaultAsync(item => item.UserName == username
            && item.Otptext == OTPText && item.Expiration > DateTime.Now);
            if (_data != null)
            {
                response = true;
            }
            return response;
        }
        public async Task<APIResponse> UpdateStatus(string username, bool userstatus)
        {
            APIResponse response = new APIResponse();
            var _user = await this._context.ApplicationUsers.FirstOrDefaultAsync(item => item.UserName == username);
            if (_user != null)
            {
                _user.EmailConfirmed = userstatus;
                await this._context.SaveChangesAsync();
                response.Result = "pass";
                response.Message = "User Status changed";
            }
            else
            {
                response.Result = "fail";
                response.Message = "Invalid User";
            }
            return response;
        }

        private async Task UpdatePWDManager(string username, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var _opt = new PwdManager()
            {
                Username = username,
                Password = hashedPassword,
                ModifyDate = DateTime.Now
            };
            await this._context.PwdManagers.AddAsync(_opt);
            await this._context.SaveChangesAsync();
        }

        private string Generaterandomnumber()
        {
            Random random = new Random();
            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }

        private async Task SendOtpMail(string useremail, string OtpText, string Name)
        {
            var mailrequest = new Mailrequest();
            mailrequest.Email = useremail;
            mailrequest.Subject = "Thanks for registering : OTP";
            mailrequest.Emailbody = GenerateEmailBody(Name, OtpText);
            await this.emailService.SendEmail(mailrequest);
        }

        private string GenerateEmailBody(string name, string otptext)
        {
            string emailbody = "<div style='width:100%;background-color:grey'>";
            emailbody += "<h1>Hi " + name + ", Thanks for registering</h1>";
            emailbody += "<h2>Please enter OTP text and complete the registeration</h2>";
            emailbody += "<h2>OTP Text is :" + otptext + "</h2>";
            emailbody += "</div>";

            return emailbody;
        }

        private async Task<bool> Validatepwdhistory(string Username, string password)
        {
            var _pwdList = await this._context.PwdManagers
                .Where(item => item.Username == Username)
                .OrderByDescending(p => p.ModifyDate)
                .Take(3)
                .ToListAsync();

            if (_pwdList.Count > 0)
            {
                foreach (var pwdEntry in _pwdList)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, pwdEntry.Password))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public async Task<List<UserModel>> Getall()
        {
            var users = await (from user in _context.ApplicationUsers
                               join userRole in _context.UserRoles on user.Id equals userRole.UserId
                               join role in _context.Roles on userRole.RoleId equals role.Id
                               select new UserModel
                               {
                                   Id = user.Id,
                                   UserName = user.UserName,
                                   Name = user.Name,
                                   Email = user.Email,
                                   Phone = user.Phone,
                                   Role = role.Name,
                                   Isactive = user.EmailConfirmed 
                               }).ToListAsync();
            return users;
        }

        public async Task<UserModel> Getbycode(string code)
        {
            UserModel _response = new UserModel();
            var _data = await this._context.ApplicationUsers.FindAsync(code);
            if (_data != null)
            {
                _response = this._mapper.Map<ApplicationUser, UserModel>(_data);
            }
            return _response;
        }
    }

}
