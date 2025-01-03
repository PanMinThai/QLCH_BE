using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QLCH_BE.Models;
using QLCH_BE.Service;
using System.Security.Cryptography;

namespace QLCH_BE.Container
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly StoreManagementDbContext _context;
        public RefreshHandler(StoreManagementDbContext context)
        {
            _context = context;
        }
        public async Task<string> GenerateToken(string username)
        {
            // Lấy UserId từ username
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            Guid userId = user.Id;

            // Tạo token ngẫu nhiên
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
            }
            string refreshtoken = Convert.ToBase64String(randomnumber);

            // Kiểm tra token đã tồn tại
            var existingToken = await _context.UserTokens.FirstOrDefaultAsync(t =>
                t.UserId == userId && t.LoginProvider == "CustomRefreshToken" && t.Name == "RefreshToken");

            if (existingToken != null)
            {
                existingToken.Value = refreshtoken; // Cập nhật token
            }
            else
            {
                // Thêm token mới
                await _context.UserTokens.AddAsync(new IdentityUserToken<Guid>
                {
                    UserId = userId,
                    LoginProvider = "CustomRefreshToken",
                    Name = "RefreshToken",
                    Value = refreshtoken
                });
            }

            await _context.SaveChangesAsync();

            return refreshtoken;
        }


    }
}
