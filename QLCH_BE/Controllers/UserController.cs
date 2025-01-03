using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QLCH_BE.Modal;
using QLCH_BE.Models.AccountManagement;
using QLCH_BE.Service;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService service)
        {
            this.userService = service;
        }

        [HttpPost("UserRegisteration")]
        public async Task<IActionResult> UserRegisteration(SignUpModel model)
        {
            var data = await this.userService.UserRegisteration(model);
            return Ok(data);
        }

        [HttpPost("ConfirmRegisteration")]
        public async Task<IActionResult> ConfirmRegisteration(ConfirmPassword _data)
        {
            var data = await this.userService.ConfirmRegister(_data.Userid, _data.UserName, _data.otptext);
            return Ok(data);
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPassword _data)
        {
            var data = await this.userService.ResetPassword(_data.UserName, _data.OldPassword, _data.NewPassword);
            return Ok(data);
        }

        [HttpGet("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string username)
        {
            var data = await this.userService.ForgetPassword(username);
            return Ok(data);
        }

        [HttpPost("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePassword _data)
        {
            var data = await this.userService.UpdatePassword(_data.UserName, _data.PassWord, _data.OtpText);
            return Ok(data);
        }

        [HttpPost("UpdateStatus")]
        public async Task<IActionResult> UpdateStatus(UpdateStatus _data)
        {
            var data = await this.userService.UpdateStatus(_data.UserName, _data.Status);
            return Ok(data);
        }

        [HttpPost("UpdateRole")]
        public async Task<IActionResult> UpdateRole(UpdateRole _data)
        {
            var data = await this.userService.UpdateRole(_data.UserName, _data.Role);
            return Ok(data);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var data = await this.userService.Getall();
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var data = await this.userService.Getbycode(code);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
