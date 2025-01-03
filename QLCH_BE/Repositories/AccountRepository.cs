using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models.AccountManagement;
using QLCH_BE.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLCH_BE.Repositories
{
    public interface IAccountRepository
    {
        ////public Task<IdentityResult> SignUpAsync(SignUpModel model);
        ////public Task<(string accessToken, string refreshToken)> SignInAsync(SignInModel model);
        public Task InitializeRolesAndSuperUserAsync();
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        //public async Task<(string accessToken, string refreshToken)> SignInAsync(SignInModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if (user == null || !(await _userManager.CheckPasswordAsync(user, model.Password)))
        //        return (string.Empty, string.Empty);

        //    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        //    if (!result.Succeeded)
        //        return (string.Empty, string.Empty);

        //    // Tạo danh sách các claims 
        //    var authClaims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Email, model.Email),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

        //    var userRoles = await _userManager.GetRolesAsync(user);
        //    foreach (var role in userRoles)
        //        authClaims.Add(new Claim(ClaimTypes.Role, role));

        //    // Tạo Access Token
        //    var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JWT:ValidIssuer"],
        //        audience: _configuration["JWT:ValidAudience"],
        //        expires: DateTime.Now.AddMinutes(20), // Thời gian hết hạn của Access Token
        //        claims: authClaims,
        //        signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
        //    );
        //    var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

        //    // Tạo Refresh Token thông qua TokenService
        //    var refreshToken = await _tokenService.CreateRefreshTokenAsync(user.Id);

        //    return (accessToken, refreshToken);
        //}

        //public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        //{
        //    var user = new ApplicationUser
        //    {
        //        Name = model.Name,
        //        Email = model.Email,
        //        UserName = model.Email
        //    };
        //    var result = await _userManager.CreateAsync(user, model.Password);
        //    if (result.Succeeded)
        //        await _userManager.AddToRoleAsync(user, ApplicationRole.Employee);
        //    return result;
        //}
        public async Task InitializeRolesAndSuperUserAsync()
        {
            // Tạo các role mặc định nếu chưa tồn tại
            string[] roleNames = { ApplicationRole.Admin, ApplicationRole.Manager, ApplicationRole.Employee };

            foreach (var roleName in roleNames)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole<Guid>(roleName));
                }
            }

            // Kiểm tra xem có super user chưa, nếu chưa thì tạo một super user mặc định
            var superUser = await _userManager.FindByEmailAsync("admin@admin.com");
            if (superUser == null)
            {
                superUser = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    Name = "Admin",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    CreatedTime = DateTime.Now,
                    UpdatedTime = DateTime.Now, 
                    Phone = "0846972196"

                };

                var result = await _userManager.CreateAsync(superUser, "Admin@123");

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(superUser, ApplicationRole.Admin);
            }
        }
    }
}
