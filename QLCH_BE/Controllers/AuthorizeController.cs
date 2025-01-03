using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QLCH_BE.Entities.Objects;
using QLCH_BE.Modal;
using QLCH_BE.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QLCH_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly IRefreshHandler _refresh;
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            IOptions<JwtSettings> options, // Cập nhật ở đây
                            IRefreshHandler refresh,
                            ILogger<AuthorizeController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = options.Value; // Lấy giá trị từ IOptions<JwtSettings>
            _refresh = refresh;
            _logger = logger;

            if (string.IsNullOrEmpty(_jwtSettings.Secret))
            {
                throw new ArgumentNullException(nameof(_jwtSettings.Secret), "JWT Secret is null or empty.");
            }

            _logger.LogInformation("JWT Secret: {Key}", _jwtSettings.Secret);
        }
    
        [HttpPost("GenerateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] UserCred userCred)
        {
            var user = await _userManager.FindByEmailAsync(userCred.username);

            if (user != null && await _userManager.CheckPasswordAsync(user, userCred.password) && user.EmailConfirmed)
            {
                // Tạo token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);
                
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, string.Join(",", await _userManager.GetRolesAsync(user)))
                };

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddSeconds(3000),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var finalToken = tokenHandler.WriteToken(token);

                return Ok(new TokenResponse
                {
                    Token = finalToken,
                    RefreshToken = await _refresh.GenerateToken(user.UserName),
                    UserRole = string.Join(",", await _userManager.GetRolesAsync(user))
                });
            }
            else
            {
                return Unauthorized();
            }
        }
        [HttpPost("GenerateRefreshToken")]
        public async Task<IActionResult> GenerateRefreshToken([FromBody] TokenResponse token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_jwtSettings.Secret);

            SecurityToken validatedToken;
            var principal = tokenHandler.ValidateToken(token.Token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                ValidateIssuer = false,
                ValidateAudience = false,
            }, out validatedToken);

            var jwtToken = validatedToken as JwtSecurityToken;
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
            {
                return Unauthorized();
            }

            var username = principal.Identity?.Name;
            if (username == null)
            {
                return Unauthorized();
            }

            // Kiểm tra refresh token
            var refreshToken = await _userManager.GetAuthenticationTokenAsync(await _userManager.FindByNameAsync(username),
                "CustomRefreshToken", "RefreshToken");

            if (refreshToken != null && refreshToken == token.RefreshToken)
            {
                // Tạo token mới
                var newToken = new JwtSecurityToken(
                    claims: principal.Claims,
                    expires: DateTime.UtcNow.AddSeconds(3000),
                    signingCredentials: new SigningCredentials(
                        new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                );

                var finalToken = tokenHandler.WriteToken(newToken);

                // Cập nhật refresh token
                var newRefreshToken = await _refresh.GenerateToken(username);
                await _userManager.SetAuthenticationTokenAsync(await _userManager.FindByNameAsync(username),
                    "CustomRefreshToken", "RefreshToken", newRefreshToken);

                return Ok(new TokenResponse
                {
                    Token = finalToken,
                    RefreshToken = newRefreshToken,
                    UserRole = token.UserRole
                });
            }

            return Unauthorized();
        }


    }
}
