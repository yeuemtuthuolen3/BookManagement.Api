using System;
namespace BookManagement.Api.Services
{
	public class AuthService
	{
        // Mã hóa mật khẩu bằng bcrypt
        public string HashPassword(string password)
        {
            // Tạo mật khẩu đã được mã hóa với salt tự động được tạo ra
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        // Kiểm tra mật khẩu đã mã hóa có khớp với mật khẩu nhập vào không
        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            // Xác thực mật khẩu nhập vào so với mật khẩu đã được mã hóa
            return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
        }
    }
}

