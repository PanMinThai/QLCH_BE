using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using QLCH_BE.Entities.Common;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLCH_BE.Repositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model);
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
        public async Task<string> SignInAsync(SignInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
                return string.Empty;
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (!result.Succeeded)
                return string.Empty;
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, ApplicationRole.Employee);
            return result;
        }
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
                    UpdatedTime = DateTime.Now
                };

                var result = await _userManager.CreateAsync(superUser, "Admin@123");

                if (result.Succeeded)
                    await _userManager.AddToRoleAsync(superUser, ApplicationRole.Admin);
            }
        }
    }
}
