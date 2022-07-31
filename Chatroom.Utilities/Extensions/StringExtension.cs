using System.Security.Cryptography;
using System.Text;

namespace Chatroom.Utilities.Extensions
{
    public static class StringExtension
    {
        public static string EncryptBySHA256(this string plaintext)
        {
            var hash = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(plaintext));
            return Convert.ToHexString(hash);
        }
    }
}
