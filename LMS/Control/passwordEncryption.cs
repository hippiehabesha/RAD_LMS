using LMS.Model;
using System.Security.Cryptography;
using System.Text;

namespace LMS.Control
{
    internal class passwordEncryption
    {
        public static string HashPassword(userModel user)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal
                }
                return builder.ToString();
            }
        }
    }
}
